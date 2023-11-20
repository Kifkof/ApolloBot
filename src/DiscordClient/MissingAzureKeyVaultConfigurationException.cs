namespace DiscordClient;

internal class MissingAzureKeyVaultConfigurationException : Exception
{
    public MissingAzureKeyVaultConfigurationException()
        :base("There was no Configuration for AzureKeyVault provided!")
    {
        
    }
}