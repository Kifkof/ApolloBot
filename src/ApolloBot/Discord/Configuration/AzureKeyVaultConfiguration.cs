namespace ApolloBot.Discord.Configuration;

public class AzureKeyVaultConfiguration
{
    public required string KeyVaultUri { get; init; }
    public required string TenantId { get; init; }
    public required string ClientId { get; init; }
    public required string CertificateThumbprint { get; init; }
    public required string DiscordTokenSecretName { get; init; }
}