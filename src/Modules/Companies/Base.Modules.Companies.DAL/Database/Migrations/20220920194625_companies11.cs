using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    public partial class companies11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "companies",
                table: "ErrorLogger");

            migrationBuilder.RenameColumn(
                name: "Table",
                schema: "companies",
                table: "ErrorLogger",
                newName: "InputData");

            migrationBuilder.RenameColumn(
                name: "Message",
                schema: "companies",
                table: "ErrorLogger",
                newName: "Class");

            migrationBuilder.RenameColumn(
                name: "Data",
                schema: "companies",
                table: "ErrorLogger",
                newName: "Exception");

            migrationBuilder.RenameColumn(
                name: "Data",
                schema: "companies",
                table: "ActionLogger",
                newName: "ObjectData");

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 20, 22, 46, 25, 621, DateTimeKind.Local).AddTicks(2882));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InputData",
                schema: "companies",
                table: "ErrorLogger",
                newName: "Table");

            migrationBuilder.RenameColumn(
                name: "Exception",
                schema: "companies",
                table: "ErrorLogger",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "Class",
                schema: "companies",
                table: "ErrorLogger",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "ObjectData",
                schema: "companies",
                table: "ActionLogger",
                newName: "Data");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "companies",
                table: "ErrorLogger",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 19, 14, 13, 13, 112, DateTimeKind.Local).AddTicks(9642));
        }
    }
}
