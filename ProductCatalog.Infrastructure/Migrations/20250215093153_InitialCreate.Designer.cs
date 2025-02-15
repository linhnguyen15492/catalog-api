﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductCatalog.Api.Infrastructure.Data;

#nullable disable

namespace ProductCatalog.Api.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogContext))]
    [Migration("20250215093153_InitialCreate")]
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

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.Branch", b =>
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

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.Category", b =>
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

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.Dimension", b =>
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

                    b.ToTable("Dimensions");
                });

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.DimensionValue", b =>
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

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BranchId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.PrimitiveCollection<string[]>("Images")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("PriceFrom")
                        .HasColumnType("double precision");

                    b.Property<double>("PriceTo")
                        .HasColumnType("double precision");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TenantId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.Variant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AvailableStock")
                        .HasColumnType("integer");

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

                    b.ToTable("Variants");
                });

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.VariantDimentionValue", b =>
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

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.Category", b =>
                {
                    b.HasOne("ProductCatalog.Api.Infrastructure.Domain.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.DimensionValue", b =>
                {
                    b.HasOne("ProductCatalog.Api.Infrastructure.Domain.Dimension", "Dimension")
                        .WithMany("DimensionValues")
                        .HasForeignKey("DimensionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dimension");
                });

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.Product", b =>
                {
                    b.HasOne("ProductCatalog.Api.Infrastructure.Domain.Branch", null)
                        .WithMany("Products")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductCatalog.Api.Infrastructure.Domain.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.Variant", b =>
                {
                    b.HasOne("ProductCatalog.Api.Infrastructure.Domain.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.VariantDimentionValue", b =>
                {
                    b.HasOne("ProductCatalog.Api.Infrastructure.Domain.Dimension", "Dimension")
                        .WithMany()
                        .HasForeignKey("DimensionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductCatalog.Api.Infrastructure.Domain.DimensionValue", "DimensionValue")
                        .WithMany()
                        .HasForeignKey("DimensionValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductCatalog.Api.Infrastructure.Domain.Variant", "Variant")
                        .WithMany("VariantDimentionValues")
                        .HasForeignKey("VariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dimension");

                    b.Navigation("DimensionValue");

                    b.Navigation("Variant");
                });

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.Branch", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.Category", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.Dimension", b =>
                {
                    b.Navigation("DimensionValues");
                });

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.Product", b =>
                {
                    b.Navigation("Variants");
                });

            modelBuilder.Entity("ProductCatalog.Api.Infrastructure.Domain.Variant", b =>
                {
                    b.Navigation("VariantDimentionValues");
                });
#pragma warning restore 612, 618
        }
    }
}
