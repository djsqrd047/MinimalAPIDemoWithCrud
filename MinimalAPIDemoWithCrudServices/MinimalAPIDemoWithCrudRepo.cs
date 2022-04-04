using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MinimalAPIDemoWithCrudDbContext;

using MinimalAPIDemoWithCrudModels;

using MinimalAPIDemoWithCrudServices.Interfaces;

namespace MinimalAPIDemoWithCrudServices
{
    public class MinimalAPIDemoWithCrudRepo : IMinimalAPIDemoWithCrudRepo
    {
        private MyDbContext _context;
        public MinimalAPIDemoWithCrudRepo(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<StoreInformation> GetAllStores()
        {
            return _context.StoreInformation.ToList();
        }

        public StoreInformation GetStoreInformation(int Id)
        {
            return _context.StoreInformation.Where(x => x.Id == Id).FirstOrDefault();
        }

        public StoreInformation GetStoreInformationByStoreNumber(int storeNumber) => _context.StoreInformation.FirstOrDefault(x => x.StoreNumber == storeNumber);

        public bool InsertNewStoreInformation(StoreInformation storeInformation)
        {
            bool saved;
            try
            {
                if (storeInformation == null)
                {
                    saved = false;
                    throw new ArgumentNullException(nameof(storeInformation));
                }
                else
                {
                    _context.StoreInformation.Add(storeInformation);
                    saved = Save();
                }

            }
            catch (Exception ex)
            {
                //log exception
                return false;
            }

            return saved;
        }

        public bool MarkAsDeleted(int Id)
        {
            bool saved = false;
            try
            {
                if (Id == null)
                {
                    saved = false;
                    throw new ArgumentNullException(nameof(Id));
                }
                else
                {
                    var storeToDelete = _context.StoreInformation.Where(x => x.Id == Id).FirstOrDefault();
                    storeToDelete.IsDeleted = true;
                    saved = UpdateStoreInformation(storeToDelete); 
                }
            }
            catch (Exception ex)
            {
                //log exception
                return false;
            }

            return saved;

            
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }



        public bool UpdateStoreInformation(StoreInformation storeInformation)
        {
            bool saved = false;
            try
            {
                if (storeInformation == null)
                {
                    saved = false;
                    throw new ArgumentNullException(nameof(storeInformation));
                }
                else
                {
                    _context.Update(storeInformation);
                    saved = Save();
                }
            }
            catch (Exception ex)
            {
                //log exception
                return false;
            }

            return saved;
        }
    }
}
