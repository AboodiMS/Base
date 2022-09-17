using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/ChangePowers",
                column: "DependsOn",
                value: new[] { "users-module/Users/GetById", "users-module/Users/GetAll" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/Delete",
                column: "DependsOn",
                value: new[] { "users-module/Users/GetById", "users-module/Users/GetAll" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/Update",
                column: "DependsOn",
                value: new[] { "users-module/Users/GetById", "users-module/Users/GetAll" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 0, 57, 6, 627, DateTimeKind.Local).AddTicks(259), "6c979df8-74bc-4ff5-afb1-db860884fce6", "OfFgb+9DWqAEX0fkzW56Fw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/ChangePowers",
                column: "DependsOn",
                value: new[] { "users-module/Users/GetById" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/Delete",
                column: "DependsOn",
                value: new[] { "users-module/Users/GetById" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/Update",
                column: "DependsOn",
                value: new[] { "users-module/Users/GetById" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 0, 36, 41, 562, DateTimeKind.Local).AddTicks(8665), "d07bedea-32f4-49ec-b5a7-6ef914264c98", "iHzHWq1AmXunRuEtPV91vA==" });
        }
    }
}
