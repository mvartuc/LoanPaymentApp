using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VakifBankKrediKullandirimAPI.Migrations
{
    /// <inheritdoc />
    public partial class PaymentPlanneededaperiodfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "PaymentPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPlans_PeriodId",
                table: "PaymentPlans",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPlans_DatePart_PeriodId",
                table: "PaymentPlans",
                column: "PeriodId",
                principalTable: "DatePart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPlans_DatePart_PeriodId",
                table: "PaymentPlans");

            migrationBuilder.DropIndex(
                name: "IX_PaymentPlans_PeriodId",
                table: "PaymentPlans");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "PaymentPlans");
        }
    }
}
