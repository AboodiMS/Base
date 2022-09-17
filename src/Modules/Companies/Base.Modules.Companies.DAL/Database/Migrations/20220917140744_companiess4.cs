using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    public partial class companiess4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreePowers_TreePowers_ParentCodeName",
                schema: "companies",
                table: "TreePowers");

            migrationBuilder.DropIndex(
                name: "IX_TreePowers_ParentCodeName",
                schema: "companies",
                table: "TreePowers");

            migrationBuilder.RenameColumn(
                name: "CodeName",
                schema: "companies",
                table: "TreePowers",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "CodeName",
                schema: "companies",
                table: "ModuleSettings",
                newName: "Code");

            migrationBuilder.AddColumn<string>(
                name: "ParentCode",
                schema: "companies",
                table: "TreePowers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Properties",
                schema: "companies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TableName = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<string>(type: "jsonb", nullable: true),
                    IsRowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Code);
                });

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 17, 17, 7, 44, 110, DateTimeKind.Local).AddTicks(3446));

            migrationBuilder.CreateIndex(
                name: "IX_TreePowers_ParentCode",
                schema: "companies",
                table: "TreePowers",
                column: "ParentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TreePowers_TreePowers_ParentCode",
                schema: "companies",
                table: "TreePowers",
                column: "ParentCode",
                principalSchema: "companies",
                principalTable: "TreePowers",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreePowers_TreePowers_ParentCode",
                schema: "companies",
                table: "TreePowers");

            migrationBuilder.DropTable(
                name: "Properties",
                schema: "companies");

            migrationBuilder.DropIndex(
                name: "IX_TreePowers_ParentCode",
                schema: "companies",
                table: "TreePowers");

            migrationBuilder.DropColumn(
                name: "ParentCode",
                schema: "companies",
                table: "TreePowers");

            migrationBuilder.RenameColumn(
                name: "Code",
                schema: "companies",
                table: "TreePowers",
                newName: "CodeName");

            migrationBuilder.RenameColumn(
                name: "Code",
                schema: "companies",
                table: "ModuleSettings",
                newName: "CodeName");

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2022, 8, 20, 14, 36, 22, 683, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.CreateIndex(
                name: "IX_TreePowers_ParentCodeName",
                schema: "companies",
                table: "TreePowers",
                column: "ParentCodeName");

            migrationBuilder.AddForeignKey(
                name: "FK_TreePowers_TreePowers_ParentCodeName",
                schema: "companies",
                table: "TreePowers",
                column: "ParentCodeName",
                principalSchema: "companies",
                principalTable: "TreePowers",
                principalColumn: "CodeName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
