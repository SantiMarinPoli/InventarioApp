using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using System.Linq;
using Entities.Interface;

namespace Business
{
    public class B_Category
    {
        public static List<CategoryEntity> CategoryList()
        {
            using (var db = new InventaryContext())
            {
                return db.Categories.ToList();
            }
        }

        public static CategoryEntity CategoryById(string id)
        {
            using (var db = new InventaryContext())
            {
                return db.Categories.ToList().LastOrDefault(p => p.CategoryId == id);
            }
        }

        public static void CRUDCategory(CategoryEntity oCategory, IOperator op)
        {
            using(var db = new InventaryContext())
            {
                switch(op)
                {
                    case IOperator.Create:
                        db.Categories.Add(oCategory);
                        db.SaveChanges();
                        break;

                    case IOperator.Update:
                        db.Categories.Update(oCategory);
                        db.SaveChanges();
                        break;
                }
            }
        }
    }
}
