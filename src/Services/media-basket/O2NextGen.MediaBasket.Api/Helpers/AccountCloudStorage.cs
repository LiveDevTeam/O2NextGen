namespace O2NextGen.MediaBasket.Api.Helpers
{
    public enum StorageType
    {
        Cloudinary,
        Azure
    }
    public class AccountCloudStorage
    {
        public string AccountName { get; set; } 
        public  string Container { get; set; }
        public  string AccountKey { get; set; }
        public TypeTable TypeTable { get; set; }
        public StorageType StorageType { get; set; }
    }
}