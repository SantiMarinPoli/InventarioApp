using DataAccess;
using Entities;
using Entities.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class B_Storage
    {
        public static List<StorageEntity> StorageList()
        {
            using (var db = new InventaryContext())
            {
                return db.Storages
                    .Include(x=>x.Product)
                    .Include(x=>x.Warehouse)
                    .ToList();
            }
        }

        public static List<StorageEntity> StorageProductsByWarehouse(string idWarehouse)
        {
            using (var db = new InventaryContext())
            {
                return db.Storages
                    .Include(x=>x.Product)
                    .Include(x=>x.Warehouse)
                    .Where(x => x.WarehouseId == idWarehouse)
                    .ToList();
            }
        }
        public static StorageEntity StorageById(string id)
        {
            using (var db = new InventaryContext())
            {
                return db.Storages.ToList().LastOrDefault(p => p.StorageId == id);
            }
        }

        public static bool IsProductInWarehouse(string idStorage)
        {
            using (var db = new InventaryContext())
            {
                var product = db.Storages.ToList()
                    .Where(x => x.StorageId == idStorage);
                return product.Any();
            }
        }
        public static void CRUDStorage(StorageEntity oStorage, IOperator op)
        {
            using (var db = new InventaryContext())
            {
                switch (op)
                {
                    case IOperator.Create:
                        db.Storages.Add(oStorage);
                        db.SaveChanges();
                        break;

                    case IOperator.Update:
                        db.Storages.Update(oStorage);
                        db.SaveChanges();
                        break;
                }
            }
        }
    }
}
