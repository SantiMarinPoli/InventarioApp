using DataAccess;
using Entities;
using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class B_Warehouse
    {
        public static List<WarehouseEntity> WarehouseList()
        {
            using (var db = new InventaryContext())
            {
                return db.Warehouses.ToList();
            }
        }
        public static WarehouseEntity WarehouseById(string id)
        {
            using (var db = new InventaryContext())
            {
                return db.Warehouses.ToList().LastOrDefault(p => p.WarehouseId == id);
            }
        }

        public static void CRUDWarehouse(WarehouseEntity oWarehouse, IOperator op)
        {
            using (var db = new InventaryContext())
            {
                switch (op)
                {
                    case IOperator.Create:
                        db.Warehouses.Add(oWarehouse);
                        db.SaveChanges();
                        break;

                    case IOperator.Update:
                        db.Warehouses.Update(oWarehouse);
                        db.SaveChanges();
                        break;
                }
            }
        }
    }
}
