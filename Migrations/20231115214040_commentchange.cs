using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBate.Migrations
{
    /// <inheritdoc />
    public partial class commentchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "comment_id",
                table: "movies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_movies_comment_id",
                table: "movies",
                column: "comment_id");

            migrationBuilder.AddForeignKey(
                name: "fk_movies_comments_comment_id",
                table: "movies",
                column: "comment_id",
                principalTable: "comments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_movies_comments_comment_id",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "ix_movies_comment_id",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "comment_id",
                table: "movies");
        }
    }
}
