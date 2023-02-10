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
    [Migration("20230206080852_Changed Stuff")]
    partial class ChangedStuff
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Helpers.CustomDateClasses.DatePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Limit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("DatePart");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Category.ProductCategory", b =>
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

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Category.ProductParentCategory", b =>
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

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Loan.Installment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AmountToBePaid")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BsmvAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InitialDebtAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InterestAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("PaymentPlanID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("PaymentPlanID");

                    b.ToTable("Installments");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Loan.PaymentPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("CrumbAmount")
                        .HasPrecision(2, 2)
                        .HasColumnType("decimal(2,2)");

                    b.Property<DateTime>("FirstPaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InterestPercentage")
                        .HasPrecision(2, 2)
                        .HasColumnType("decimal(2,2)");

                    b.Property<DateTime?>("LastPaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PeriodId")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("RepaymentTermID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("PeriodId");

                    b.HasIndex("RepaymentTermID");

                    b.ToTable("PaymentPlans");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Loan.RepaymentTerm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MonthID")
                        .HasColumnType("int");

                    b.Property<int>("YearID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("MonthID");

                    b.HasIndex("YearID");

                    b.ToTable("RepaymentTerm");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Parameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Product", b =>
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

                    b.Property<int>("PaymentPlanID")
                        .HasColumnType("int");

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

                    b.HasIndex("PaymentPlanID");

                    b.HasIndex("ProductCategoryID");

                    b.HasIndex("SpecialOfferID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.SpecialOffer", b =>
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

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Category.ProductCategory", b =>
                {
                    b.HasOne("VakifBankKrediKullandirimAPI.Models.Category.ProductParentCategory", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Loan.Installment", b =>
                {
                    b.HasOne("VakifBankKrediKullandirimAPI.Models.Loan.PaymentPlan", null)
                        .WithMany("Installments")
                        .HasForeignKey("PaymentPlanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Loan.PaymentPlan", b =>
                {
                    b.HasOne("VakifBankKrediKullandirimAPI.Helpers.CustomDateClasses.DatePart", "Period")
                        .WithMany()
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VakifBankKrediKullandirimAPI.Models.Loan.RepaymentTerm", "RepaymentTerm")
                        .WithMany()
                        .HasForeignKey("RepaymentTermID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Period");

                    b.Navigation("RepaymentTerm");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Loan.RepaymentTerm", b =>
                {
                    b.HasOne("VakifBankKrediKullandirimAPI.Helpers.CustomDateClasses.DatePart", "Month")
                        .WithMany()
                        .HasForeignKey("MonthID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VakifBankKrediKullandirimAPI.Helpers.CustomDateClasses.DatePart", "Year")
                        .WithMany()
                        .HasForeignKey("YearID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Month");

                    b.Navigation("Year");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Product", b =>
                {
                    b.HasOne("VakifBankKrediKullandirimAPI.Models.Loan.PaymentPlan", "PaymentPlan")
                        .WithMany()
                        .HasForeignKey("PaymentPlanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VakifBankKrediKullandirimAPI.Models.Category.ProductCategory", "Category")
                        .WithMany()
                        .HasForeignKey("ProductCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VakifBankKrediKullandirimAPI.Models.SpecialOffer", "SpecialOffer")
                        .WithMany()
                        .HasForeignKey("SpecialOfferID");

                    b.Navigation("Category");

                    b.Navigation("PaymentPlan");

                    b.Navigation("SpecialOffer");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.SpecialOffer", b =>
                {
                    b.HasOne("VakifBankKrediKullandirimAPI.Models.Category.ProductCategory", "ProductCategory")
                        .WithMany("SpecialOffers")
                        .HasForeignKey("ProductCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Category.ProductCategory", b =>
                {
                    b.Navigation("SpecialOffers");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Category.ProductParentCategory", b =>
                {
                    b.Navigation("ChildCategories");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Loan.PaymentPlan", b =>
                {
                    b.Navigation("Installments");
                });
#pragma warning restore 612, 618
        }
    }
}
