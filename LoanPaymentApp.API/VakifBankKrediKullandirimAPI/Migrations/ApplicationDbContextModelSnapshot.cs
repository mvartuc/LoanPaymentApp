﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VakifBankKrediKullandirimAPI.Data;

#nullable disable

namespace VakifBankKrediKullandirimAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Helpers.CustomDateClasses.DatePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Limit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("DatePart");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Category.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ParentCategoryID")
                        .HasColumnType("INTEGER");

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
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("ParentCategories");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Loan.Installment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("AmountToBePaid")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("BsmvAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("InitialDebtAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("InterestAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentPlanID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("RemainingInitialDebtAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

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
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("BsmvPercentageDisplayValue")
                        .HasPrecision(5, 2)
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CrumbAmount")
                        .HasPrecision(2, 2)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FirstPaymentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("InstallmentTypeCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("InterestPercentage")
                        .HasPrecision(5, 5)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastPaymentDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PeriodId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RepaymentTermID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalAmountToBePaid")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalBsmvAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalInitialDebtAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalInterestAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("PeriodId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("RepaymentTermID");

                    b.ToTable("PaymentPlans");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Loan.RepaymentTerm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MonthID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YearID")
                        .HasColumnType("INTEGER");

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
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductCategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SpecialOfferID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UsageTypeCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ProductCategoryID");

                    b.HasIndex("SpecialOfferID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.SpecialOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductCategoryID")
                        .HasColumnType("INTEGER");

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

                    b.HasOne("VakifBankKrediKullandirimAPI.Models.Product", "Product")
                        .WithOne("PaymentPlan")
                        .HasForeignKey("VakifBankKrediKullandirimAPI.Models.Loan.PaymentPlan", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VakifBankKrediKullandirimAPI.Models.Loan.RepaymentTerm", "RepaymentTerm")
                        .WithMany()
                        .HasForeignKey("RepaymentTermID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Period");

                    b.Navigation("Product");

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
                    b.HasOne("VakifBankKrediKullandirimAPI.Models.Category.ProductCategory", "Category")
                        .WithMany()
                        .HasForeignKey("ProductCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VakifBankKrediKullandirimAPI.Models.SpecialOffer", "SpecialOffer")
                        .WithMany()
                        .HasForeignKey("SpecialOfferID");

                    b.Navigation("Category");

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

            modelBuilder.Entity("VakifBankKrediKullandirimAPI.Models.Product", b =>
                {
                    b.Navigation("PaymentPlan")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}