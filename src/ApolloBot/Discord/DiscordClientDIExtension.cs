using Discord;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ApolloBot.Discord
{
    public static class DiscordClientDIExtension
    {
        public static IServiceCollection AddDiscordClient(this IServiceCollection services)
        {
            services.TryAddSingleton<DiscordClientHealthCheck>();
            services.AddHostedService<DiscordClientService>();
            services.AddHealthChecks()
                .AddCheck<DiscordClientHealthCheck>("discord_client_health_check");

            return services;
        }
    }

    public class DiscordClientHealthCheck : IHealthCheck
    {
        private volatile ConnectionState connectionState;
        public ConnectionState ConnectionState
        {
            get => this.connectionState;
            set => this.connectionState = value;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            var currentConnectionState = this.ConnectionState;
            return currentConnectionState switch
            {
                ConnectionState.Connected => Task.FromResult(HealthCheckResult.Healthy(currentConnectionState.ToString())),
                ConnectionState.Connecting => Task.FromResult(HealthCheckResult.Unhealthy(currentConnectionState.ToString())),
                ConnectionState.Disconnecting => Task.FromResult(HealthCheckResult.Unhealthy(currentConnectionState.ToString())),
                ConnectionState.Disconnected => Task.FromResult(HealthCheckResult.Unhealthy(currentConnectionState.ToString())),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
