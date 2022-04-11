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
    public class B_InOut
    {
        public static List<InOutEntity> InOutList()
        {
            using (var db = new InventaryContext())
            {
                return db.InOuts
                    .Include(x=>x.Storage.Product)
                    .ToList();
            }
        }
        public static InOutEntity InOutById(string id)
        {
            using (var db = new InventaryContext())
            {
                return db.InOuts.ToList().LastOrDefault(p => p.InOutId == id);
            }
        }
        public static void CRUDInOut(InOutEntity oInOut, IOperator op)
        {
            using (var db = new InventaryContext())
            {
                switch (op)
                {
                    case IOperator.Create:
                        db.InOuts.Add(oInOut);
                        db.SaveChanges();
                        break;

                    case IOperator.Update:
                        db.InOuts.Update(oInOut);
                        db.SaveChanges();
                        break;
                }
            }
        }
    }
}
