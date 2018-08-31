using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeniusBase.Core.Migrations
{
    public partial class articletableupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FirstPublishedDate",
                schema: "post",
                table: "Article",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArchivedDate",
                schema: "post",
                table: "Article",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                schema: "post",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "ModifiedBy" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FirstPublishedDate",
                schema: "post",
                table: "Article",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArchivedDate",
                schema: "post",
                table: "Article",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "post",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "ModifiedBy" },
                values: new object[] { 0, 0 });
        }
    }
}
