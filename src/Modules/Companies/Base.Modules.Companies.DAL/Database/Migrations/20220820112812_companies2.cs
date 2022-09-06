using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    public partial class companies2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModuleSettings",
                schema: "companies",
                columns: table => new
                {
                    CodeName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Setting = table.Column<object>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleSettings", x => x.CodeName);
                });

            migrationBuilder.CreateTable(
                name: "TreePowers",
                schema: "companies",
                columns: table => new
                {
                    CodeName = table.Column<string>(type: "text", nullable: false),
                    Num = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsEndPoint = table.Column<bool>(type: "boolean", nullable: false),
                    DependsOn = table.Column<string[]>(type: "jsonb", nullable: true),
                    ParentCodeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreePowers", x => x.CodeName);
                    table.ForeignKey(
                        name: "FK_TreePowers_TreePowers_ParentCodeName",
                        column: x => x.ParentCodeName,
                        principalSchema: "companies",
                        principalTable: "TreePowers",
                        principalColumn: "CodeName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2022, 8, 20, 14, 28, 12, 293, DateTimeKind.Local).AddTicks(1275));

            migrationBuilder.InsertData(
                schema: "companies",
                table: "ModuleSettings",
                columns: new[] { "CodeName", "Name", "Setting" },
                values: new object[] { "companies-modules", "Companies Managament", null });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "TreePowers",
                columns: new[] { "CodeName", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCodeName" },
                values: new object[] { "users-module", null, false, "قسم المستخدمين", 1, null });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "TreePowers",
                columns: new[] { "CodeName", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCodeName" },
                values: new object[] { "users-module/Users", null, false, "معلومات المستخدمين", 101, "users-module" });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "TreePowers",
                columns: new[] { "CodeName", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCodeName" },
                values: new object[,]
                {
                    { "users-module/Users/Add", null, true, "اضافة", 10103, "users-module/Users" },
                    { "users-module/Users/ChangePowers", new[] { "users-module/Users/GetById" }, true, "تعديل الصلاحيات", 10106, "users-module/Users" },
                    { "users-module/Users/Delete", new[] { "users-module/Users/GetById" }, true, "حذف", 10105, "users-module/Users" },
                    { "users-module/Users/GetAll", null, true, "عرض الكل", 10101, "users-module/Users" },
                    { "users-module/Users/GetById", null, true, "عرض", 10102, "users-module/Users" },
                    { "users-module/Users/Update", new[] { "users-module/Users/GetById" }, true, "تعديل", 10104, "users-module/Users" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreePowers_ParentCodeName",
                schema: "companies",
                table: "TreePowers",
                column: "ParentCodeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleSettings",
                schema: "companies");

            migrationBuilder.DropTable(
                name: "TreePowers",
                schema: "companies");

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2022, 8, 17, 13, 24, 56, 710, DateTimeKind.Local).AddTicks(8060));
        }
    }
}
