using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VakifBankKrediKullandirimAPI.Migrations
{
    /// <inheritdoc />
    public partial class Parametercodesarenotuniqueanymore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Parameters_Code",
                table: "Parameters");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Parameters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Parameters",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_Code",
                table: "Parameters",
                column: "Code",
                unique: true);
        }
    }
}
