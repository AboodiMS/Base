using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    public partial class InitialCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "companies");

            migrationBuilder.CreateTable(
                name: "ActionLogger",
                schema: "companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Table = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    ObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectData = table.Column<object>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CompanyWork = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ActiveSections = table.Column<string[]>(type: "jsonb", nullable: true),
                    ExpiryDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    FirstActiveDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastActiveDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleSettings",
                schema: "companies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Settings = table.Column<object>(type: "jsonb", nullable: true),
                    xmin = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleSettings", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                schema: "companies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TreePowers",
                schema: "companies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Num = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsEndPoint = table.Column<bool>(type: "boolean", nullable: false),
                    DependsOn = table.Column<string[]>(type: "jsonb", nullable: true),
                    ParentCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreePowers", x => x.Code);
                    table.ForeignKey(
                        name: "FK_TreePowers_TreePowers_ParentCode",
                        column: x => x.ParentCode,
                        principalSchema: "companies",
                        principalTable: "TreePowers",
                        principalColumn: "Code");
                });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "Companies",
                columns: new[] { "Id", "ActiveSections", "CompanyWork", "CreatedDate", "CreatedUserId", "ExpiryDate", "FirstActiveDate", "LastActiveDate", "LastUpdateDate", "LastUpdateUserId", "Name" },
                values: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new[] { "Accounting" }, "", new DateTimeOffset(new DateTime(2023, 1, 21, 7, 21, 50, 501, DateTimeKind.Unspecified).AddTicks(4642), new TimeSpan(0, 3, 0, 0, 0)), new Guid("11111111-1111-1111-1111-111111111111"), null, null, null, null, null, "اسم الشركة" });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "ModuleSettings",
                columns: new[] { "Code", "Name", },
                values: new object[] { "companies-modules", "Companies Managament" });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "TreePowers",
                columns: new[] { "Code", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCode" },
                values: new object[] { "companies-module", null, false, "قسم الشركة", 1, null });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "TreePowers",
                columns: new[] { "Code", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCode" },
                values: new object[] { "companies-module/Companies", null, false, "معلومات الشركة", 101, "companies-module" });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "TreePowers",
                columns: new[] { "Code", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCode" },
                values: new object[] { "companies-module/Companies/Update", null, true, "تعديل", 10102, "companies-module/Companies" });

            migrationBuilder.CreateIndex(
                name: "IX_Company_Name",
                schema: "companies",
                table: "Companies",
                column: "Name",
                unique: true,
                filter: "\"IsDeleted\" = false ");

            migrationBuilder.CreateIndex(
                name: "IX_Section_Name",
                schema: "companies",
                table: "Sections",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreePowers_ParentCode",
                schema: "companies",
                table: "TreePowers",
                column: "ParentCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLogger",
                schema: "companies");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "companies");

            migrationBuilder.DropTable(
                name: "ModuleSettings",
                schema: "companies");

            migrationBuilder.DropTable(
                name: "Sections",
                schema: "companies");

            migrationBuilder.DropTable(
                name: "TreePowers",
                schema: "companies");
        }
    }
}
