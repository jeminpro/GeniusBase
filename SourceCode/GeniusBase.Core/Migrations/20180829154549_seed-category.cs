using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeniusBase.Core.Migrations
{
    public partial class seedcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tag_TagIdentifier",
                schema: "post",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "TagIdentifier",
                schema: "post",
                table: "Tag");

            migrationBuilder.InsertData(
                schema: "post",
                table: "Category",
                columns: new[] { "Id", "CategoryIdentifier", "CategoryName", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { 1, "uncategorized", "Uncategorized", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "post",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "TagIdentifier",
                schema: "post",
                table: "Tag",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagIdentifier",
                schema: "post",
                table: "Tag",
                column: "TagIdentifier",
                unique: true);
        }
    }
}
