namespace ApolloBot.Discord;

public interface IDiscordBotTokenProvider
{
    Task<string> GetBotTokenAsync();
}