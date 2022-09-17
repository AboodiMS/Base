using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    public partial class companies10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRowVersion",
                schema: "companies",
                table: "ModuleSettings");

            migrationBuilder.DropColumn(
                name: "IsRowVersion",
                schema: "companies",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "CodeName",
                schema: "companies",
                table: "Sections",
                newName: "Code");

            migrationBuilder.AddColumn<long>(
                name: "xmin",
                schema: "companies",
                table: "ModuleSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<uint>(
                name: "xmin",
                schema: "companies",
                table: "Companies",
                type: "xid",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 19, 14, 13, 13, 112, DateTimeKind.Local).AddTicks(9642));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "xmin",
                schema: "companies",
                table: "ModuleSettings");

            migrationBuilder.DropColumn(
                name: "xmin",
                schema: "companies",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "Code",
                schema: "companies",
                table: "Sections",
                newName: "CodeName");

            migrationBuilder.AddColumn<byte[]>(
                name: "IsRowVersion",
                schema: "companies",
                table: "ModuleSettings",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "IsRowVersion",
                schema: "companies",
                table: "Companies",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 18, 1, 19, 20, 793, DateTimeKind.Local).AddTicks(7678));
        }
    }
}
