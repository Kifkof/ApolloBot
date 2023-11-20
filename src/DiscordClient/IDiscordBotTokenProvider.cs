namespace DiscordClient;

public interface IDiscordBotTokenProvider
{
    Task<string> GetBotTokenAsync();
}