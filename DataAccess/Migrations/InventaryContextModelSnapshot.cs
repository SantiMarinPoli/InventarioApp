﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(InventaryContext))]
    partial class InventaryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.CategoryEntity", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "ASH",
                            CategoryName = "ASEO HOGAR"
                        },
                        new
                        {
                            CategoryId = "HGR",
                            CategoryName = "HOGAR"
                        },
                        new
                        {
                            CategoryId = "PRF",
                            CategoryName = "PERFUMERIA"
                        },
                        new
                        {
                            CategoryId = "SLD",
                            CategoryName = "SALUD"
                        },
                        new
                        {
                            CategoryId = "VDJ",
                            CategoryName = "VIDEO JUEGOS"
                        });
                });

            modelBuilder.Entity("Entities.InOutEntity", b =>
                {
                    b.Property<string>("InOutId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("InOutDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsInput")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("StorageId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InOutId");

                    b.HasIndex("StorageId");

                    b.ToTable("InOuts");
                });

            modelBuilder.Entity("Entities.ProductEntity", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(600)")
                        .HasMaxLength(600);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Entities.StorageEntity", b =>
                {
                    b.Property<string>("StorageId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PartialQuantity")
                        .HasColumnType("int");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WarehouseId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StorageId");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("Entities.WarehouseEntity", b =>
                {
                    b.Property<string>("WarehouseId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("WarehouseAddress")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouses");

                    b.HasData(
                        new
                        {
                            WarehouseId = "1334b8ba-667d-4bf1-9627-b36820d86883",
                            WarehouseAddress = "Calle 8 con 23",
                            WarehouseName = "Bodega Central"
                        },
                        new
                        {
                            WarehouseId = "74967791-0cf6-4a0a-bd6f-f9f7bde5e2bf",
                            WarehouseAddress = "Calle Norte 80 con 30",
                            WarehouseName = "Bodega Norte"
                        });
                });

            modelBuilder.Entity("Entities.InOutEntity", b =>
                {
                    b.HasOne("Entities.StorageEntity", "Storage")
                        .WithMany("InOuts")
                        .HasForeignKey("StorageId");
                });

            modelBuilder.Entity("Entities.ProductEntity", b =>
                {
                    b.HasOne("Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Entities.StorageEntity", b =>
                {
                    b.HasOne("Entities.ProductEntity", "Product")
                        .WithMany("Storages")
                        .HasForeignKey("ProductId");

                    b.HasOne("Entities.WarehouseEntity", "Warehouse")
                        .WithMany("Storages")
                        .HasForeignKey("WarehouseId");
                });
#pragma warning restore 612, 618
        }
    }
}
