using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VakifBankKrediKullandirimAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemovedParameterFKaddedapropinstead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Parameters_Par_UsageTypeID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Par_UsageTypeID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Par_UsageTypeID",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "UsageTypeCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsageTypeCode",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Par_UsageTypeID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Par_UsageTypeID",
                table: "Products",
                column: "Par_UsageTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Parameters_Par_UsageTypeID",
                table: "Products",
                column: "Par_UsageTypeID",
                principalTable: "Parameters",
                principalColumn: "Id");
        }
    }
}
