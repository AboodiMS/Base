using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    public partial class companies13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2023, 1, 20, 20, 56, 54, 165, DateTimeKind.Local).AddTicks(2188));

            migrationBuilder.InsertData(
                schema: "companies",
                table: "ModuleSettings",
                columns: new[] { "Code", "Name" },
                values: new object[] { "companies-modules", "Companies Managament"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "companies",
                table: "ModuleSettings",
                keyColumn: "Code",
                keyValue: "companies-modules");

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 23, 12, 9, 59, 535, DateTimeKind.Local).AddTicks(4382));
        }
    }
}
