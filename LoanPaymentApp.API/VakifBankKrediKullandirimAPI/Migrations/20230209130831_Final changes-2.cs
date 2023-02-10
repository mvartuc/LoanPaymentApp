using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VakifBankKrediKullandirimAPI.Migrations
{
    /// <inheritdoc />
    public partial class Finalchanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PaymentPlans_PaymentPlanID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PaymentPlanID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PaymentPlanID",
                table: "Products",
                newName: "PaymentPlanId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "PaymentPlans",
                newName: "ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentPlanId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentPlans_ProductId",
                table: "PaymentPlans",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPlans_Products_ProductId",
                table: "PaymentPlans",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPlans_Products_ProductId",
                table: "PaymentPlans");

            migrationBuilder.DropIndex(
                name: "IX_PaymentPlans_ProductId",
                table: "PaymentPlans");

            migrationBuilder.RenameColumn(
                name: "PaymentPlanId",
                table: "Products",
                newName: "PaymentPlanID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "PaymentPlans",
                newName: "ProductID");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentPlanID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PaymentPlanID",
                table: "Products",
                column: "PaymentPlanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PaymentPlans_PaymentPlanID",
                table: "Products",
                column: "PaymentPlanID",
                principalTable: "PaymentPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
