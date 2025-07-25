﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend_dotnet.Data;

#nullable disable

namespace backend_dotnet.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250612092635_ChangeDoubleInProductPromoTable")]
    partial class ChangeDoubleInProductPromoTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("backend_dotnet.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Image")
                        .HasColumnType("longtext")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("slug");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("backend_dotnet.Entities.Courier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Couriers");
                });

            modelBuilder.Entity("backend_dotnet.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Image")
                        .HasColumnType("longtext")
                        .HasColumnName("image");

                    b.Property<int?>("IsActive")
                        .HasColumnType("int")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Number")
                        .HasColumnType("longtext")
                        .HasColumnName("number");

                    b.Property<string>("OwnerName")
                        .HasColumnType("longtext")
                        .HasColumnName("owner_name");

                    b.Property<string>("Type")
                        .HasColumnType("longtext")
                        .HasColumnName("type");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("backend_dotnet.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("brand_id");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .HasColumnType("longtext")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double")
                        .HasColumnName("price");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("slug");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("backend_dotnet.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("slug");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("backend_dotnet.Entities.ProductPromo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<decimal>("DiscountNominal")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("discount_nominal");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("valid_until");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPromo");
                });

            modelBuilder.Entity("backend_dotnet.Entities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Qty")
                        .HasColumnType("int")
                        .HasColumnName("qty");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("type");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("backend_dotnet.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("role");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("backend_dotnet.Entities.Product", b =>
                {
                    b.HasOne("backend_dotnet.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.HasOne("backend_dotnet.Entities.ProductCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("backend_dotnet.Entities.ProductPromo", b =>
                {
                    b.HasOne("backend_dotnet.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("backend_dotnet.Entities.Stock", b =>
                {
                    b.HasOne("backend_dotnet.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
