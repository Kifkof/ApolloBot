using DiscordClient;
using Microsoft.AspNetCore.Mvc;

namespace ApolloBot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BotHealthController : ControllerBase
    {
        private readonly DiscordClientHealthCheck discordClientHealthCheck;

        public BotHealthController(DiscordClientHealthCheck discordClientHealthCheck)
        {
            this.discordClientHealthCheck = discordClientHealthCheck;
        }

        [HttpGet]
        public BotHealth Get()
        {
            return new BotHealth
            {
                ConnectionState = this.discordClientHealthCheck.ConnectionState.ToString(),
            };
        }
    }

    public class BotHealth
    {
        public string? ConnectionState { get; set; }
    }
}