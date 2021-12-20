﻿// <auto-generated />
using System;
using CarPartsOnline.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarPartsOnline.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211214124817_InitialOrderMigration")]
    partial class InitialOrderMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarPartsOnline.Models.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("orderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CarPartsOnline.Models.OrderProduct", b =>
                {
                    b.Property<int>("orderProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.HasKey("orderProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("CarPartsOnline.Models.Product", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("productDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("productPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("productID");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
