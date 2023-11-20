using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DiscordClient
{
    public class DiscordClientService : BackgroundService
    {
        private readonly ILogger<DiscordClientService> logger;
        private readonly DiscordClientHealthCheck discordClientHealthCheck;
        private readonly IDiscordBotTokenProvider discordBotTokenProvider;
        private DiscordSocketClient? client;

        public DiscordClientService(ILogger<DiscordClientService> logger, 
            DiscordClientHealthCheck discordClientHealthCheck, 
            IDiscordBotTokenProvider discordBotTokenProvider)
        {
            this.logger = logger;
            this.discordClientHealthCheck = discordClientHealthCheck;
            this.discordBotTokenProvider = discordBotTokenProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.client = new DiscordSocketClient();
            this.client.Log += this.OnDiscordLogAsync;

            var botToken = await this.discordBotTokenProvider.GetBotTokenAsync();

            await this.client.LoginAsync(TokenType.Bot, botToken);
            await this.client.StartAsync();

            this.client.Ready += this.ClientOnReady;

            while (!stoppingToken.IsCancellationRequested)
            {
                this.discordClientHealthCheck.ConnectionState = this.client.ConnectionState;
                await Task.Delay(2000, stoppingToken);
            }

            await this.client.StopAsync();
        }

        private async Task ClientOnReady()
        {
            var botTestChannel = this.client!.GetChannel(1150733956577234984);
            if (botTestChannel is ITextChannel textChannel)
            {
                await textChannel.SendMessageAsync($"Test Message with Key Vault", true);
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
