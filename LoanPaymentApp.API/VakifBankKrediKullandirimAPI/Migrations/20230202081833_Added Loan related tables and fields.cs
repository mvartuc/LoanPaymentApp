using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VakifBankKrediKullandirimAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedLoanrelatedtablesandfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentPlanID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DatePart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Limit = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatePart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepaymentTerm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YearID = table.Column<int>(type: "int", nullable: false),
                    MonthID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentTerm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepaymentTerm_DatePart_MonthID",
                        column: x => x.MonthID,
                        principalTable: "DatePart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepaymentTerm_DatePart_YearID",
                        column: x => x.YearID,
                        principalTable: "DatePart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    InterestPercentage = table.Column<decimal>(type: "decimal(2,2)", precision: 2, scale: 2, nullable: false),
                    FirstPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepaymentTermID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPlans", x => x.Id);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountToBePaid = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    InterestAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentPlanID = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Products_PaymentPlanID",
                table: "Products",
                column: "PaymentPlanID");

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
                name: "IX_PaymentPlans_Code",
                table: "PaymentPlans",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPlans_RepaymentTermID",
                table: "PaymentPlans",
                column: "RepaymentTermID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PaymentPlans_PaymentPlanID",
                table: "Products",
                column: "PaymentPlanID",
                principalTable: "PaymentPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PaymentPlans_PaymentPlanID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Installments");

            migrationBuilder.DropTable(
                name: "PaymentPlans");

            migrationBuilder.DropTable(
                name: "RepaymentTerm");

            migrationBuilder.DropTable(
                name: "DatePart");

            migrationBuilder.DropIndex(
                name: "IX_Products_PaymentPlanID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PaymentPlanID",
                table: "Products");
        }
    }
}
