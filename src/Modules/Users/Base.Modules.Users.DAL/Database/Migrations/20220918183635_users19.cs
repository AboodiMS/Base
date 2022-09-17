using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "xmin",
                schema: "users",
                table: "CustomPowers");

            migrationBuilder.AlterColumn<uint>(
                name: "xmin",
                schema: "users",
                table: "Users",
                type: "xid",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                oldClrType: typeof(string),
                oldType: "text",
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "users",
                table: "Users",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "users",
                table: "CustomPowers",
                type: "bytea",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 21, 36, 35, 400, DateTimeKind.Local).AddTicks(5961), "7a1f9cfd-5f82-4e11-8614-fed8910a9510", "3aXYs46WfVwGSJfqT8PTEQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "users",
                table: "CustomPowers");

            migrationBuilder.AlterColumn<string>(
                name: "xmin",
                schema: "users",
                table: "Users",
                type: "text",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(uint),
                oldType: "xid",
                oldRowVersion: true);

            migrationBuilder.AddColumn<string>(
                name: "xmin",
                schema: "users",
                table: "CustomPowers",
                type: "text",
                rowVersion: true,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 21, 29, 0, 287, DateTimeKind.Local).AddTicks(698), "2e29ecb8-2def-4d66-a507-838ad8f09cb7", "eFCph7N+0RrTM8+c6fGNPg==" });
        }
    }
}
