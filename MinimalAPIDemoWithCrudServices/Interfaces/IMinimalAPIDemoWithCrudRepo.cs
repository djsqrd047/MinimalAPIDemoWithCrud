using System;
using System.Collections.Generic;
using System.Text;

using MinimalAPIDemoWithCrudModels;

namespace MinimalAPIDemoWithCrudServices.Interfaces
{
    public interface IMinimalAPIDemoWithCrudRepo
    {
        public IEnumerable<StoreInformation> GetAllStores();
        public StoreInformation GetStoreInformation(int Id);
        public StoreInformation GetStoreInformationByStoreNumber(int storeNumber);
        public bool MarkAsDeleted(int Id);
        public bool InsertNewStoreInformation(StoreInformation storeInformation);
        public bool UpdateStoreInformation(StoreInformation storeInformation);
        public bool Save();
    }
}
