using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "users",
                table: "ErrorLogger");

            migrationBuilder.RenameColumn(
                name: "Table",
                schema: "users",
                table: "ErrorLogger",
                newName: "InputData");

            migrationBuilder.RenameColumn(
                name: "Message",
                schema: "users",
                table: "ErrorLogger",
                newName: "Class");

            migrationBuilder.RenameColumn(
                name: "Data",
                schema: "users",
                table: "ErrorLogger",
                newName: "Exception");

            migrationBuilder.RenameColumn(
                name: "Data",
                schema: "users",
                table: "ActionLogger",
                newName: "ObjectData");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 20, 22, 45, 35, 164, DateTimeKind.Local).AddTicks(5660), "790bfa9d-39d4-4c7d-9bc8-d17fc3b01525", "2hulQOUE7d5npSjVRjWCtw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InputData",
                schema: "users",
                table: "ErrorLogger",
                newName: "Table");

            migrationBuilder.RenameColumn(
                name: "Exception",
                schema: "users",
                table: "ErrorLogger",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "Class",
                schema: "users",
                table: "ErrorLogger",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "ObjectData",
                schema: "users",
                table: "ActionLogger",
                newName: "Data");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "users",
                table: "ErrorLogger",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 19, 14, 29, 46, 787, DateTimeKind.Local).AddTicks(4577), "bed51277-7c99-47e7-84bc-5d7405b0782f", "n9LR71f0DSb3uMgzwSV6Ew==" });
        }
    }
}
