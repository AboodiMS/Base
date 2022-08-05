using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "users");

            migrationBuilder.CreateTable(
                name: "TreePowers",
                schema: "users",
                columns: table => new
                {
                    CodeName = table.Column<string>(type: "text", nullable: false),
                    Num = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsEndPoint = table.Column<bool>(type: "boolean", nullable: false),
                    DependsOn = table.Column<string[]>(type: "text[]", nullable: true),
                    ParentCodeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreePowers", x => x.CodeName);
                    table.ForeignKey(
                        name: "FK_TreePowers_TreePowers_ParentCodeName",
                        column: x => x.ParentCodeName,
                        principalSchema: "users",
                        principalTable: "TreePowers",
                        principalColumn: "CodeName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "users",
                table: "TreePowers",
                columns: new[] { "CodeName", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCodeName" },
                values: new object[,]
                {
                    { "companies-module", null, false, "قسم الشركة", 1, null },
                    { "users-module", null, false, "قسم المستخدمين", 2, null }
                });

            migrationBuilder.InsertData(
                schema: "users",
                table: "TreePowers",
                columns: new[] { "CodeName", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCodeName" },
                values: new object[,]
                {
                    { "companies-module/Companies", null, false, "معلومات الشركة", 101, "companies-module" },
                    { "users-module/Users", null, false, "معلومات المستخدمين", 201, "users-module" }
                });

            migrationBuilder.InsertData(
                schema: "users",
                table: "TreePowers",
                columns: new[] { "CodeName", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCodeName" },
                values: new object[,]
                {
                    { "companies-module/Companies/GetById", null, true, "عرض", 10101, "companies-module/Companies" },
                    { "companies-module/Companies/Update", new[] { "companies-module/Companies/GetById" }, true, "تعديل", 10102, "companies-module/Companies" },
                    { "companies-module/Companies/UpdateActiveSections", new[] { "companies-module/Companies/GetById" }, true, "تعديل", 10103, "companies-module/Companies" },
                    { "users-module/Users/Add", null, true, "اضافة", 20103, "users-module/Users" },
                    { "users-module/Users/ChangePowers", new[] { "users-module/Users/GetById" }, true, "تعديل الصلاحيات", 20106, "users-module/Users" },
                    { "users-module/Users/Delete", new[] { "users-module/Users/GetById" }, true, "حذف", 20105, "users-module/Users" },
                    { "users-module/Users/GetAll", null, true, "عرض الكل", 20101, "users-module/Users" },
                    { "users-module/Users/GetById", null, true, "عرض", 20102, "users-module/Users" },
                    { "users-module/Users/Update", new[] { "users-module/Users/GetById" }, true, "تعديل", 20104, "users-module/Users" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreePowers_ParentCodeName",
                schema: "users",
                table: "TreePowers",
                column: "ParentCodeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreePowers",
                schema: "users");
        }
    }
}
