using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VakifBankKrediKullandirimAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedTotalfieldstoPaymentPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "PaymentPlans",
                newName: "TotalInterestAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmountToBePaid",
                table: "PaymentPlans",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalBsmvAmount",
                table: "PaymentPlans",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalInitialDebtAmount",
                table: "PaymentPlans",
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
                name: "TotalAmountToBePaid",
                table: "PaymentPlans");

            migrationBuilder.DropColumn(
                name: "TotalBsmvAmount",
                table: "PaymentPlans");

            migrationBuilder.DropColumn(
                name: "TotalInitialDebtAmount",
                table: "PaymentPlans");

            migrationBuilder.RenameColumn(
                name: "TotalInterestAmount",
                table: "PaymentPlans",
                newName: "TotalAmount");
        }
    }
}
