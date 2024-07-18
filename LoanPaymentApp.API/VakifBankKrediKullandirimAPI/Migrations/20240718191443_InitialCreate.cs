using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VakifBankKrediKullandirimAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatePart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    Limit = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatePart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    GroupCode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepaymentTerm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    YearID = table.Column<int>(type: "INTEGER", nullable: false),
                    MonthID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentTerm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepaymentTerm_DatePart_MonthID",
                        column: x => x.MonthID,
                        principalTable: "DatePart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepaymentTerm_DatePart_YearID",
                        column: x => x.YearID,
                        principalTable: "DatePart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ParentCategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_ParentCategories_ParentCategoryID",
                        column: x => x.ParentCategoryID,
                        principalTable: "ParentCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ProductCategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialOffers_Categories_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ProductCategoryID = table.Column<int>(type: "INTEGER", nullable: false),
                    SpecialOfferID = table.Column<int>(type: "INTEGER", nullable: true),
                    UsageTypeCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SpecialOffers_SpecialOfferID",
                        column: x => x.SpecialOfferID,
                        principalTable: "SpecialOffers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalInitialDebtAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    InterestPercentage = table.Column<decimal>(type: "TEXT", precision: 5, scale: 5, nullable: false),
                    BsmvPercentageDisplayValue = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: false),
                    FirstPaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RepaymentTermID = table.Column<int>(type: "INTEGER", nullable: false),
                    PeriodId = table.Column<int>(type: "INTEGER", nullable: false),
                    InstallmentTypeCode = table.Column<string>(type: "TEXT", nullable: false),
                    CrumbAmount = table.Column<decimal>(type: "TEXT", precision: 2, scale: 2, nullable: false),
                    TotalInterestAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    TotalBsmvAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    TotalAmountToBePaid = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentPlans_DatePart_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "DatePart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentPlans_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentPlans_RepaymentTerm_RepaymentTermID",
                        column: x => x.RepaymentTermID,
                        principalTable: "RepaymentTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Installments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InitialDebtAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    InterestAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    BsmvAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    AmountToBePaid = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    RemainingInitialDebtAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    PaymentPlanID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Installments_PaymentPlans_PaymentPlanID",
                        column: x => x.PaymentPlanID,
                        principalTable: "PaymentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Code",
                table: "Categories",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryID",
                table: "Categories",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_DatePart_Code",
                table: "DatePart",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Installments_Code",
                table: "Installments",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Installments_PaymentPlanID",
                table: "Installments",
                column: "PaymentPlanID");

            migrationBuilder.CreateIndex(
                name: "IX_ParentCategories_Code",
                table: "ParentCategories",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPlans_Code",
                table: "PaymentPlans",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPlans_PeriodId",
                table: "PaymentPlans",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPlans_ProductId",
                table: "PaymentPlans",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPlans_RepaymentTermID",
                table: "PaymentPlans",
                column: "RepaymentTermID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryID",
                table: "Products",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SpecialOfferID",
                table: "Products",
                column: "SpecialOfferID");

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentTerm_Code",
                table: "RepaymentTerm",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentTerm_MonthID",
                table: "RepaymentTerm",
                column: "MonthID");

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentTerm_YearID",
                table: "RepaymentTerm",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOffers_Code",
                table: "SpecialOffers",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOffers_ProductCategoryID",
                table: "SpecialOffers",
                column: "ProductCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Installments");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "PaymentPlans");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RepaymentTerm");

            migrationBuilder.DropTable(
                name: "SpecialOffers");

            migrationBuilder.DropTable(
                name: "DatePart");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ParentCategories");
        }
    }
}
