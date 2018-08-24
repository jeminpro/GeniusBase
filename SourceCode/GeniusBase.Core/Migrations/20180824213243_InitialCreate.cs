using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeniusBase.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "post");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "post",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(maxLength: 30, nullable: false),
                    CategoryShortName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ArticleHistory",
                schema: "post",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ArticleHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    IsDraft = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleHistory", x => x.ArticleHistoryId);
                    table.ForeignKey(
                        name: "FK_ArticleHistory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "post",
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTag",
                schema: "post",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ArticleTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTag", x => x.ArticleTagId);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                schema: "post",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    UrlIdentifier = table.Column<string>(maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlainContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDraft = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Views = table.Column<int>(nullable: false),
                    FirstPublishedDate = table.Column<DateTime>(nullable: false),
                    ArchivedDate = table.Column<DateTime>(nullable: false),
                    ArticleTagId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Article_ArticleTag_ArticleTagId",
                        column: x => x.ArticleTagId,
                        principalSchema: "post",
                        principalTable: "ArticleTag",
                        principalColumn: "ArticleTagId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Article_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "post",
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                schema: "post",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TagName = table.Column<string>(maxLength: 30, nullable: false),
                    TagShortName = table.Column<string>(maxLength: 30, nullable: false),
                    ArticleHistoryId = table.Column<int>(nullable: true),
                    ArticleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tag_ArticleHistory_ArticleHistoryId",
                        column: x => x.ArticleHistoryId,
                        principalSchema: "post",
                        principalTable: "ArticleHistory",
                        principalColumn: "ArticleHistoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tag_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "post",
                        principalTable: "Article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_ArticleTagId",
                schema: "post",
                table: "Article",
                column: "ArticleTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_CategoryId",
                schema: "post",
                table: "Article",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_UrlIdentifier",
                schema: "post",
                table: "Article",
                column: "UrlIdentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleHistory_CategoryId",
                schema: "post",
                table: "ArticleHistory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_ArticleId",
                schema: "post",
                table: "ArticleTag",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_TagId",
                schema: "post",
                table: "ArticleTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ArticleHistoryId",
                schema: "post",
                table: "Tag",
                column: "ArticleHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ArticleId",
                schema: "post",
                table: "Tag",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Article_ArticleId",
                schema: "post",
                table: "ArticleTag",
                column: "ArticleId",
                principalSchema: "post",
                principalTable: "Article",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Tag_TagId",
                schema: "post",
                table: "ArticleTag",
                column: "TagId",
                principalSchema: "post",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_ArticleTag_ArticleTagId",
                schema: "post",
                table: "Article");

            migrationBuilder.DropTable(
                name: "ArticleTag",
                schema: "post");

            migrationBuilder.DropTable(
                name: "Tag",
                schema: "post");

            migrationBuilder.DropTable(
                name: "ArticleHistory",
                schema: "post");

            migrationBuilder.DropTable(
                name: "Article",
                schema: "post");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "post");
        }
    }
}
