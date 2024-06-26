﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication4.Models;

#nullable disable

namespace WebApplication4.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]
    partial class ApplicationDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication4.Models.product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebApplication4.Models.stockInDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int?>("prodId")
                        .HasColumnType("int");

                    b.Property<int>("quantitySold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("prodId");

                    b.ToTable("StockInDetails");
                });

            modelBuilder.Entity("WebApplication4.Models.stockInDetail", b =>
                {
                    b.HasOne("WebApplication4.Models.product", "prod")
                        .WithMany("stockInDetails")
                        .HasForeignKey("prodId");

                    b.Navigation("prod");
                });

            modelBuilder.Entity("WebApplication4.Models.product", b =>
                {
                    b.Navigation("stockInDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
