using System.Collections.Generic;
using System.Linq;
using O2NextGen.MediaBasket.Api.Helpers;

namespace O2NextGen.MediaBasket.Api.Services
{
    public abstract class CloudStorage: Singleton<CloudStorage>
    {
        public List<AccountCloudStorage> AccountCloudStorages { get; set; } = new List<AccountCloudStorage>();
        
        protected CloudStorage()
        {
            Clear();
        }

        public AccountCloudStorage GetAccountCloudStorage(TypeTable typeTable)
        {
            return AccountCloudStorages.Single(x => x.TypeTable == typeTable);
        }

        public void Clear()
        {
            AccountCloudStorages.Clear();
        }
    }
}