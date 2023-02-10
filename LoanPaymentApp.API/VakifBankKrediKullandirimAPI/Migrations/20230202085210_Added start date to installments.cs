﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VakifBankKrediKullandirimAPI.Migrations
{
    /// <inheritdoc />
    public partial class Addedstartdatetoinstallments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Installments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Installments");
        }
    }
}
