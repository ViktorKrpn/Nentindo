using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nentindo.Migrations
{
    /// <inheritdoc />
    public partial class _3rd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Newsletters_NewsletterId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_NewsletterId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "NewsletterId",
                table: "Articles");

            migrationBuilder.CreateTable(
                name: "ArticleNewsletter",
                columns: table => new
                {
                    ArticlesId = table.Column<int>(type: "int", nullable: false),
                    NewslettersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleNewsletter", x => new { x.ArticlesId, x.NewslettersId });
                    table.ForeignKey(
                        name: "FK_ArticleNewsletter_Articles_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArticleNewsletter_Newsletters_NewslettersId",
                        column: x => x.NewslettersId,
                        principalTable: "Newsletters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleNewsletter_NewslettersId",
                table: "ArticleNewsletter",
                column: "NewslettersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleNewsletter");

            migrationBuilder.AddColumn<int>(
                name: "NewsletterId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_NewsletterId",
                table: "Articles",
                column: "NewsletterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Newsletters_NewsletterId",
                table: "Articles",
                column: "NewsletterId",
                principalTable: "Newsletters",
                principalColumn: "Id");
        }
    }
}
