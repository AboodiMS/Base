using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreePowers_TreePowers_ParentCodeName",
                schema: "users",
                table: "TreePowers");

            migrationBuilder.DropIndex(
                name: "IX_TreePowers_ParentCodeName",
                schema: "users",
                table: "TreePowers");

            migrationBuilder.RenameColumn(
                name: "CodeName",
                schema: "users",
                table: "TreePowers",
                newName: "Code");

            migrationBuilder.AddColumn<string>(
                name: "ParentCode",
                schema: "users",
                table: "TreePowers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 16, 0, 39, 41, 523, DateTimeKind.Local).AddTicks(8491), "daefa1c4-3a76-4840-a865-c00e213017fc", "9TaWnWyfbOpW8mvMt8phgA==" });

            migrationBuilder.CreateIndex(
                name: "IX_TreePowers_ParentCode",
                schema: "users",
                table: "TreePowers",
                column: "ParentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TreePowers_TreePowers_ParentCode",
                schema: "users",
                table: "TreePowers",
                column: "ParentCode",
                principalSchema: "users",
                principalTable: "TreePowers",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreePowers_TreePowers_ParentCode",
                schema: "users",
                table: "TreePowers");

            migrationBuilder.DropIndex(
                name: "IX_TreePowers_ParentCode",
                schema: "users",
                table: "TreePowers");

            migrationBuilder.DropColumn(
                name: "ParentCode",
                schema: "users",
                table: "TreePowers");

            migrationBuilder.RenameColumn(
                name: "Code",
                schema: "users",
                table: "TreePowers",
                newName: "CodeName");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 16, 0, 34, 21, 295, DateTimeKind.Local).AddTicks(6406), "671a82e9-93be-4ad1-898f-bdfe579c10b3", "zie8v2dG3rMSSeYsx36JMg==" });

            migrationBuilder.CreateIndex(
                name: "IX_TreePowers_ParentCodeName",
                schema: "users",
                table: "TreePowers",
                column: "ParentCodeName");

            migrationBuilder.AddForeignKey(
                name: "FK_TreePowers_TreePowers_ParentCodeName",
                schema: "users",
                table: "TreePowers",
                column: "ParentCodeName",
                principalSchema: "users",
                principalTable: "TreePowers",
                principalColumn: "CodeName");
        }
    }
}
