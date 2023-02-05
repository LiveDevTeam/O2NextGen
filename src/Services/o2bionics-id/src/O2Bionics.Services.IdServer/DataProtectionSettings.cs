namespace O2Bionics.Services.IdServer;

public class DataProtectionSettings
{
    public string KeyVaultKeyId { get; set; }
    public string AadTenantId { get; set; }
    public string StorageAccountName { get; set; }
    public string StorageKeyContainerName { get; set; }
    public string StorageKeyBlobName { get; set; }
    public string StorageDevKeyBlobName { get; set; }
}