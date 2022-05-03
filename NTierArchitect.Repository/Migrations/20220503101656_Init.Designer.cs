﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NTierArchitect.Repository;

#nullable disable

namespace NTierArchitect.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220503101656_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NTierArchitect.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 5, 3, 13, 16, 56, 736, DateTimeKind.Local).AddTicks(1332),
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 5, 3, 13, 16, 56, 736, DateTimeKind.Local).AddTicks(1340),
                            Name = "Kitaplar"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2022, 5, 3, 13, 16, 56, 736, DateTimeKind.Local).AddTicks(1342),
                            Name = "Defterler"
                        });
                });

            modelBuilder.Entity("NTierArchitect.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 5, 3, 13, 16, 56, 736, DateTimeKind.Local).AddTicks(1641),
                            Name = "Kalem1",
                            Price = 40m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 5, 3, 13, 16, 56, 736, DateTimeKind.Local).AddTicks(1645),
                            Name = "Kalem2",
                            Price = 25m,
                            Stock = 110
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 5, 3, 13, 16, 56, 736, DateTimeKind.Local).AddTicks(1647),
                            Name = "Kitap1",
                            Price = 150m,
                            Stock = 75
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2022, 5, 3, 13, 16, 56, 736, DateTimeKind.Local).AddTicks(1648),
                            Name = "Defter1",
                            Price = 30m,
                            Stock = 60
                        });
                });

            modelBuilder.Entity("NTierArchitect.Core.Models.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Kırmızı",
                            Height = 100,
                            ProductId = 1,
                            Width = 100
                        },
                        new
                        {
                            Id = 2,
                            Color = "Mavi",
                            Height = 75,
                            ProductId = 2,
                            Width = 150
                        });
                });

            modelBuilder.Entity("NTierArchitect.Core.Models.Product", b =>
                {
                    b.HasOne("NTierArchitect.Core.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NTierArchitect.Core.Models.ProductFeature", b =>
                {
                    b.HasOne("NTierArchitect.Core.Models.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("NTierArchitect.Core.Models.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NTierArchitect.Core.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NTierArchitect.Core.Models.Product", b =>
                {
                    b.Navigation("ProductFeature")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
