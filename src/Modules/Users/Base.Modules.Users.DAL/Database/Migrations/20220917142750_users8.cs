using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCodeName",
                schema: "users",
                table: "TreePowers");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users",
                column: "ParentCode",
                value: "users-module");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/Add",
                column: "ParentCode",
                value: "users-module/Users");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/ChangePowers",
                column: "ParentCode",
                value: "users-module/Users");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/Delete",
                column: "ParentCode",
                value: "users-module/Users");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/GetAll",
                column: "ParentCode",
                value: "users-module/Users");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/GetById",
                column: "ParentCode",
                value: "users-module/Users");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/Update",
                column: "ParentCode",
                value: "users-module/Users");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 17, 17, 27, 49, 757, DateTimeKind.Local).AddTicks(4615), "7ffeb14d-a8c9-42f6-8ef9-ac8c31304848", "kQNPrDKgMDJ42+hvlggRrQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentCodeName",
                schema: "users",
                table: "TreePowers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users",
                columns: new[] { "ParentCode", "ParentCodeName" },
                values: new object[] { null, "users-module" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/Add",
                columns: new[] { "ParentCode", "ParentCodeName" },
                values: new object[] { null, "users-module/Users" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/ChangePowers",
                columns: new[] { "ParentCode", "ParentCodeName" },
                values: new object[] { null, "users-module/Users" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/Delete",
                columns: new[] { "ParentCode", "ParentCodeName" },
                values: new object[] { null, "users-module/Users" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/GetAll",
                columns: new[] { "ParentCode", "ParentCodeName" },
                values: new object[] { null, "users-module/Users" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/GetById",
                columns: new[] { "ParentCode", "ParentCodeName" },
                values: new object[] { null, "users-module/Users" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/Update",
                columns: new[] { "ParentCode", "ParentCodeName" },
                values: new object[] { null, "users-module/Users" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 16, 20, 49, 51, 537, DateTimeKind.Local).AddTicks(6479), "89da29f0-49cc-4da0-8ac9-c53f7bd7026c", "DJJpnGvvGkZTFX3jPsJf8Q==" });
        }
    }
}
