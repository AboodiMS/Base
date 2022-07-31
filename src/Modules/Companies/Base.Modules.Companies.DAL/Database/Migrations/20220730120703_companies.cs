using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    public partial class companies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "companies");

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CompanyWork = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ActiveSections = table.Column<string[]>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                schema: "companies",
                columns: table => new
                {
                    CodeName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.CodeName);
                });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "Companies",
                columns: new[] { "Id", "ActiveSections", "CompanyWork", "Name" },
                values: new object[] { new Guid("15a1bb12-a2b1-4af3-97c1-001e57d14744"), new[] { "Accounting" }, "", "اسم الشركة" });

            migrationBuilder.CreateIndex(
                name: "IX_Company_Name",
                schema: "companies",
                table: "Companies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Section_Name",
                schema: "companies",
                table: "Sections",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies",
                schema: "companies");

            migrationBuilder.DropTable(
                name: "Sections",
                schema: "companies");
        }
    }
}
