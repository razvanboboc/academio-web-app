using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Influencers.Models.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Votes = table.Column<int>(nullable: true),
                    ImageSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author_Id = table.Column<int>(nullable: true),
                    Title = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Votes = table.Column<int>(nullable: false),
                    ImageSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Article__Author___398D8EEE",
                        column: x => x.Author_Id,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTags",
                columns: table => new
                {
                    Article_Id = table.Column<int>(nullable: false),
                    Tag_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTags", x => new { x.Article_Id, x.Tag_Id });
                    table.ForeignKey(
                        name: "FK__ArticleTa__Artic__3E52440B",
                        column: x => x.Article_Id,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ArticleTa__Tag_I__3F466844",
                        column: x => x.Tag_Id,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author_Id = table.Column<int>(nullable: true),
                    Article_Id = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Votes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Comment__Article__4D94879B",
                        column: x => x.Article_Id,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Comment__Author___4CA06362",
                        column: x => x.Author_Id,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_Author_Id",
                table: "Article",
                column: "Author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_Tag_Id",
                table: "ArticleTags",
                column: "Tag_Id");

            migrationBuilder.CreateIndex(
                name: "UQ__ArticleT__7D0083163AC3ED2A",
                table: "ArticleTags",
                columns: new[] { "Article_Id", "Tag_Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Article_Id",
                table: "Comment",
                column: "Article_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Author_Id",
                table: "Comment",
                column: "Author_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTags");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
