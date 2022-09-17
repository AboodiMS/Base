using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/Add");

            migrationBuilder.InsertData(
                schema: "users",
                table: "TreePowers",
                columns: new[] { "Code", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCode" },
                values: new object[] { "users-module/Users/Create", null, true, "اضافة", 10103, "users-module/Users" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 0, 36, 41, 562, DateTimeKind.Local).AddTicks(8665), "d07bedea-32f4-49ec-b5a7-6ef914264c98", "iHzHWq1AmXunRuEtPV91vA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "users-module/Users/Create");

            migrationBuilder.InsertData(
                schema: "users",
                table: "TreePowers",
                columns: new[] { "Code", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCode" },
                values: new object[] { "users-module/Users/Add", null, true, "اضافة", 10103, "users-module/Users" });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 0, 31, 15, 384, DateTimeKind.Local).AddTicks(3955), "7b8fb66c-61c0-4d1e-8440-ab64be4c0b38", "hWsYyefQ4m2oVkXrl4AxbA==" });
        }
    }
}
