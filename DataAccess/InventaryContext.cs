using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class InventaryContext:DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<InOutEntity> InOuts { get; set; }
        public DbSet<StorageEntity> Storages { get; set; }
        public DbSet<WarehouseEntity> Warehouses { get; set; }
        //Funcion de conectar las bases de datos
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //si no esta configurado el db
            if(!options.IsConfigured)
            {//Server=SANTI;Database=InventoryDB;User id=SANTI;
                options.UseSqlServer("data source=SANTIAGO;Initial Catalog = InventoryDB; Integrated Security = True; ");
            }
        }

        //Opcion de realizar pruebas datos sin necesidad conectar las bases de datos
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.Entity<CategoryEntity>().HasData(
                new CategoryEntity 
                {
                CategoryId = "ASH",
                CategoryName = "ASEO HOGAR"
                },
                new CategoryEntity{CategoryId = "HGR", CategoryName = "HOGAR"},
                new CategoryEntity { CategoryId = "PRF", CategoryName = "PERFUMERIA" },
                new CategoryEntity { CategoryId = "SLD", CategoryName = "SALUD" },
                new CategoryEntity { CategoryId = "VDJ", CategoryName = "VIDEO JUEGOS" }
                );

            model.Entity<WarehouseEntity>().HasData(
                    new WarehouseEntity 
                    { 
                        WarehouseId=Guid.NewGuid().ToString(),
                        WarehouseName = "Bodega Central",
                        WarehouseAddress = "Calle 8 con 23"
                    },
                    new WarehouseEntity
                    {
                        WarehouseId = Guid.NewGuid().ToString(),
                        WarehouseName = "Bodega Norte",
                        WarehouseAddress = "Calle Norte 80 con 30"
                    }
                );
        }
    }
}
