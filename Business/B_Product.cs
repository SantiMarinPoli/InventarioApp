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
    public class B_Product
    {
        public static List<ProductEntity> ProductList()
        {
            using (var db = new InventaryContext())
            {
                return db.Products
                    .Include(x => x.Category)
                    .ToList();
            }
        }
        public static ProductEntity ProductById(string id)
        {
            using (var db = new InventaryContext())
            {
                return db.Products.ToList().LastOrDefault(p => p.ProductId == id);
            }
        }
        public static void CRUDProduct(ProductEntity oProduct, IOperator op)
        {
            using (var db = new InventaryContext())
            {
                switch (op)
                {
                    case IOperator.Create:
                        db.Products.Add(oProduct);
                        db.SaveChanges();
                        break;

                    case IOperator.Update:
                        db.Products.Update(oProduct);
                        db.SaveChanges();
                        break;
                }
            }
        }
    }
}
