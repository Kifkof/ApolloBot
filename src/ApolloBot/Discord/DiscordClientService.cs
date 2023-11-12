using Discord;
using Discord.WebSocket;

namespace ApolloBot.Discord
{
    public class DiscordClientService : BackgroundService
    {
        private readonly ILogger<DiscordClientService> logger;
        private readonly DiscordClientHealthCheck discordClientHealthCheck;
        private DiscordSocketClient? client;

        public DiscordClientService(ILogger<DiscordClientService> logger, DiscordClientHealthCheck discordClientHealthCheck)
        {
            this.logger = logger;
            this.discordClientHealthCheck = discordClientHealthCheck;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            client = new DiscordSocketClient();
            client.Log += OnDiscordLogAsync;

            await client.LoginAsync(TokenType.Bot, "BOT_TOKEN_HERE");
            await client.StartAsync();

            client.Ready += ClientOnReady;

            while (!stoppingToken.IsCancellationRequested)
            {
                this.discordClientHealthCheck.ConnectionState = client.ConnectionState;
                await Task.Delay(2000, stoppingToken);
            }

            await client.StopAsync();
        }

        private async Task ClientOnReady()
        {
            var botTestChannel = client!.GetChannel(1150733956577234984);
            if (botTestChannel is ITextChannel textChannel)
            {
                var knoggi = await textChannel.GetUserAsync(177729405890723840);
                await textChannel.SendMessageAsync($"Dä {knoggi.DisplayName} isch en knilsch", true);
                this.logger.LogInformation("Startup Message Send");
            }
        }

        private Task OnDiscordLogAsync(LogMessage logMessage)
        {
            switch (logMessage.Severity)
            {
                case LogSeverity.Critical:
                    this.logger.LogCritical(logMessage.Exception, logMessage.Message);
                    break;
                case LogSeverity.Error:
                    this.logger.LogError(logMessage.Exception, logMessage.Message);
                    break;
                case LogSeverity.Warning:
                    this.logger.LogWarning(logMessage.Exception, logMessage.Message);
                    break;
                case LogSeverity.Info:
                    this.logger.LogInformation(logMessage.Exception, logMessage.Message);
                    break;
                case LogSeverity.Debug:
                    this.logger.LogDebug(logMessage.Exception, logMessage.Message);
                    break;
                case LogSeverity.Verbose:
                    this.logger.LogTrace(logMessage.Exception, logMessage.Message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Task.CompletedTask;
        }
    }
}
