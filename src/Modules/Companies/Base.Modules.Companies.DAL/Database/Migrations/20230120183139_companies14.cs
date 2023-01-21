using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    public partial class companies14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                schema: "companies",
                table: "Companies",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstActiveDate",
                schema: "companies",
                table: "Companies",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActiveDate",
                schema: "companies",
                table: "Companies",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2023, 1, 20, 21, 31, 38, 916, DateTimeKind.Local).AddTicks(8692));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                schema: "companies",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FirstActiveDate",
                schema: "companies",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastActiveDate",
                schema: "companies",
                table: "Companies");

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2023, 1, 20, 20, 56, 54, 165, DateTimeKind.Local).AddTicks(2188));
        }
    }
}
