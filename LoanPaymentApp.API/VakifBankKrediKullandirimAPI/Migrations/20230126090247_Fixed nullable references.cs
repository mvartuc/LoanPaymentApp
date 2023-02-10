using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VakifBankKrediKullandirimAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fixednullablereferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Parameters_Par_UsageTypeID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Par_UsageTypeID",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Parameters_Par_UsageTypeID",
                table: "Products",
                column: "Par_UsageTypeID",
                principalTable: "Parameters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Parameters_Par_UsageTypeID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Par_UsageTypeID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Parameters_Par_UsageTypeID",
                table: "Products",
                column: "Par_UsageTypeID",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
