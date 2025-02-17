﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductCatalog.Infrastructure.Data;

#nullable disable

namespace ProductCatalog.Infrastructure.Migrations;

[DbContext(typeof(CatalogContext))]
[Migration("20250216184817_InitialCreate")]
partial class InitialCreate
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "9.0.2")
            .HasAnnotation("Relational:MaxIdentifierLength", 63);

        NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Brand", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<Guid>("TenantId")
                    .HasColumnType("uuid");

                b.HasKey("Id");

                b.HasIndex("TenantId");

                b.ToTable("Brands");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Category", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<Guid>("ParentId")
                    .HasColumnType("uuid");

                b.Property<Guid>("TenantId")
                    .HasColumnType("uuid");

                b.HasKey("Id");

                b.HasIndex("ParentId");

                b.HasIndex("TenantId");

                b.ToTable("Categories");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Dimension", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<string>("DisplayName")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<int>("DisplayType")
                    .HasColumnType("integer");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<Guid>("ProductId")
                    .HasColumnType("uuid");

                b.HasKey("Id");

                b.HasIndex("ProductId");

                b.ToTable("Dimensions");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.DimensionValue", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<Guid>("DimensionId")
                    .HasColumnType("uuid");

                b.Property<string>("Value")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.HasIndex("DimensionId");

                b.ToTable("DimensionValues");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Product", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<Guid>("BrandId")
                    .HasColumnType("uuid");

                b.Property<Guid>("CategoryId")
                    .HasColumnType("uuid");

                b.Property<DateTime>("CreatedAt")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("text");

                b.PrimitiveCollection<string[]>("Images")
                    .IsRequired()
                    .HasColumnType("text[]");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("boolean");

                b.Property<bool>("IsPublished")
                    .HasColumnType("boolean");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<double>("PriceFrom")
                    .HasColumnType("double precision");

                b.Property<double>("PriceTo")
                    .HasColumnType("double precision");

                b.Property<Guid>("TenantId")
                    .HasColumnType("uuid");

                b.Property<DateTime>("UpdatedAt")
                    .HasColumnType("timestamp with time zone");

                b.Property<int>("VariantCount")
                    .HasColumnType("integer");

                b.HasKey("Id");

                b.HasIndex("BrandId");

                b.HasIndex("CategoryId");

                b.HasIndex("TenantId");

                b.ToTable("Products");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Variant", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<int>("AvailableStock")
                    .HasColumnType("integer");

                b.Property<bool>("IsDeleted")
                    .HasColumnType("boolean");

                b.Property<bool>("IsPublished")
                    .HasColumnType("boolean");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<double>("Price")
                    .HasColumnType("double precision");

                b.Property<Guid>("ProductId")
                    .HasColumnType("uuid");

                b.Property<string>("Sku")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.HasIndex("AvailableStock");

                b.HasIndex("Price");

                b.HasIndex("ProductId");

                b.HasIndex("IsPublished", "IsDeleted")
                    .IsDescending(true, false);

                b.ToTable("Variants");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.VariantDimentionValue", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<Guid>("DimensionId")
                    .HasColumnType("uuid");

                b.Property<Guid>("DimensionValueId")
                    .HasColumnType("uuid");

                b.Property<string>("Value")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<Guid>("VariantId")
                    .HasColumnType("uuid");

                b.HasKey("Id");

                b.HasIndex("DimensionId");

                b.HasIndex("DimensionValueId");

                b.HasIndex("VariantId");

                b.ToTable("VariantDimentionValues");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Category", b =>
            {
                b.HasOne("ProductCatalog.Infrastructure.Entities.Category", "Parent")
                    .WithMany("Children")
                    .HasForeignKey("ParentId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Parent");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Dimension", b =>
            {
                b.HasOne("ProductCatalog.Infrastructure.Entities.Product", null)
                    .WithMany("Dimensions")
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.DimensionValue", b =>
            {
                b.HasOne("ProductCatalog.Infrastructure.Entities.Dimension", "Dimension")
                    .WithMany("DimensionValues")
                    .HasForeignKey("DimensionId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Dimension");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Product", b =>
            {
                b.HasOne("ProductCatalog.Infrastructure.Entities.Brand", "Brand")
                    .WithMany("Products")
                    .HasForeignKey("BrandId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("ProductCatalog.Infrastructure.Entities.Category", "Category")
                    .WithMany("Products")
                    .HasForeignKey("CategoryId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Brand");

                b.Navigation("Category");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Variant", b =>
            {
                b.HasOne("ProductCatalog.Infrastructure.Entities.Product", "Product")
                    .WithMany("Variants")
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Product");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.VariantDimentionValue", b =>
            {
                b.HasOne("ProductCatalog.Infrastructure.Entities.Dimension", "Dimension")
                    .WithMany()
                    .HasForeignKey("DimensionId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("ProductCatalog.Infrastructure.Entities.DimensionValue", "DimensionValue")
                    .WithMany()
                    .HasForeignKey("DimensionValueId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("ProductCatalog.Infrastructure.Entities.Variant", "Variant")
                    .WithMany("VariantDimentionValues")
                    .HasForeignKey("VariantId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Dimension");

                b.Navigation("DimensionValue");

                b.Navigation("Variant");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Brand", b =>
            {
                b.Navigation("Products");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Category", b =>
            {
                b.Navigation("Children");

                b.Navigation("Products");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Dimension", b =>
            {
                b.Navigation("DimensionValues");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Product", b =>
            {
                b.Navigation("Dimensions");

                b.Navigation("Variants");
            });

        modelBuilder.Entity("ProductCatalog.Infrastructure.Entities.Variant", b =>
            {
                b.Navigation("VariantDimentionValues");
            });
#pragma warning restore 612, 618
    }
}
