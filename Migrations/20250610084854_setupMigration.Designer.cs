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
    [Migration("20250610084854_setupMigration")]
    partial class setupMigration
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
                        .HasColumnName("createdAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updatedAt");

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

                    b.Property<string>("Image")
                        .HasColumnType("longtext")
                        .HasColumnName("image");

                    b.Property<int?>("IsActive")
                        .HasColumnType("int")
                        .HasColumnName("isActive");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Number")
                        .HasColumnType("longtext")
                        .HasColumnName("number");

                    b.Property<string>("OwnerName")
                        .HasColumnType("longtext")
                        .HasColumnName("ownerName");

                    b.Property<string>("Type")
                        .HasColumnType("longtext")
                        .HasColumnName("type");

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

                    b.Property<int?>("brandId")
                        .HasColumnType("int");

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

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("backend_dotnet.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

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
#pragma warning restore 612, 618
        }
    }
}
