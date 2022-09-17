using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                schema: "users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "users",
                table: "CustomPowers");

            migrationBuilder.AddColumn<string>(
                name: "xmin",
                schema: "users",
                table: "Users",
                type: "text",
                rowVersion: true,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "xmin",
                schema: "users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "xmin",
                schema: "users",
                table: "CustomPowers");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "users",
                table: "Users",
                type: "integer",
                rowVersion: true,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "users",
                table: "CustomPowers",
                type: "integer",
                rowVersion: true,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 21, 26, 19, 608, DateTimeKind.Local).AddTicks(4522), "366feb46-45b9-4427-ad34-ae9c4cb49e8c", "dk5wPILHoFfhVWWUQMVVTQ==" });
        }
    }
}
