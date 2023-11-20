using System.Security.Cryptography.X509Certificates;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using DiscordClient.Configuration;
using Microsoft.Extensions.Options;

namespace DiscordClient;

internal class AzureKeyVaultDiscordBotTokenProvider : IDiscordBotTokenProvider
{
    private readonly IOptions<DiscordClientOptions> discordClientOptions;

    public AzureKeyVaultDiscordBotTokenProvider(IOptions<DiscordClientOptions> discordClientOptions)
    {
        this.discordClientOptions = discordClientOptions;
    }

    public Task<string> GetBotTokenAsync()
    {
        if (this.discordClientOptions.Value.AzureKeyVault == null)
            throw new MissingAzureKeyVaultConfigurationException();

        var cert = GetCertificateFromStore(this.discordClientOptions.Value.AzureKeyVault);
        var botToken = GetBotTokenFromKeyVault(this.discordClientOptions.Value.AzureKeyVault, cert);

        return Task.FromResult(botToken);
    }

    private static string GetBotTokenFromKeyVault(AzureKeyVaultConfiguration azureKeyVaultConfiguration, X509Certificate2 cert)
    {
        var clientCertificateCredential = new ClientCertificateCredential(azureKeyVaultConfiguration.TenantId, azureKeyVaultConfiguration.ClientId, cert);
        var secretClient = new SecretClient(new Uri(azureKeyVaultConfiguration.KeyVaultUri), clientCertificateCredential);
        return secretClient.GetSecret(azureKeyVaultConfiguration.DiscordTokenSecretName).Value.Value;
    }

    private static X509Certificate2 GetCertificateFromStore(AzureKeyVaultConfiguration azureKeyVaultConfiguration)
    {
        using var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
        store.Open(OpenFlags.ReadOnly);
        var certs = store.Certificates.Find(X509FindType.FindByThumbprint, azureKeyVaultConfiguration.CertificateThumbprint, false);
        return certs[0];
    }
}