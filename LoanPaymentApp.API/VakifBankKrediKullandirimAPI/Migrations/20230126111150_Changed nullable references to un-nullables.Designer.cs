﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VakifBankKrediKullandirimAPI.Data;

#nullable disable

namespace VakifBankKrediKullandirimAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230126111150_Changed nullable references to un-nullables")]
    partial class Changednullablereferencestounnullables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Parameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductCategoryID")
                        .HasColumnType("int");

                    b.Property<int?>("SpecialOfferID")
                        .HasColumnType("int");

                    b.Property<string>("UsageTypeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ProductCategoryID");

                    b.HasIndex("SpecialOfferID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentCategoryID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ParentCategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.ProductParentCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("ParentCategories");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.SpecialOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductCategoryID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ProductCategoryID");

                    b.ToTable("SpecialOffers");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Product", b =>
                {
                    b.HasOne("VakifBankKrediKullandirimAPI.ProductCategory", "Category")
                        .WithMany()
                        .HasForeignKey("ProductCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VakifBankKrediKullandirimAPI.SpecialOffer", "SpecialOffer")
                        .WithMany()
                        .HasForeignKey("SpecialOfferID");

                    b.Navigation("Category");

                    b.Navigation("SpecialOffer");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.ProductCategory", b =>
                {
                    b.HasOne("VakifBankKrediKullandirimAPI.ProductParentCategory", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.SpecialOffer", b =>
                {
                    b.HasOne("VakifBankKrediKullandirimAPI.ProductCategory", "ProductCategory")
                        .WithMany("SpecialOffers")
                        .HasForeignKey("ProductCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.ProductCategory", b =>
                {
                    b.Navigation("SpecialOffers");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.ProductParentCategory", b =>
                {
                    b.Navigation("ChildCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
