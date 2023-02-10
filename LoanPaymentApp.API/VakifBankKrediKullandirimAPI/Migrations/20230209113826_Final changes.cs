using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VakifBankKrediKullandirimAPI.Migrations
{
    /// <inheritdoc />
    public partial class Finalchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "InterestPercentage",
                table: "PaymentPlans",
                type: "decimal(5,5)",
                precision: 5,
                scale: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldPrecision: 2,
                oldScale: 2);

            migrationBuilder.AddColumn<decimal>(
                name: "BsmvPercentageDisplayValue",
                table: "PaymentPlans",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "InstallmentTypeCode",
                table: "PaymentPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "RemainingInitialDebtAmount",
                table: "Installments",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BsmvPercentageDisplayValue",
                table: "PaymentPlans");

            migrationBuilder.DropColumn(
                name: "InstallmentTypeCode",
                table: "PaymentPlans");

            migrationBuilder.DropColumn(
                name: "RemainingInitialDebtAmount",
                table: "Installments");

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestPercentage",
                table: "PaymentPlans",
                type: "decimal(2,2)",
                precision: 2,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,5)",
                oldPrecision: 5,
                oldScale: 5);
        }
    }
}
