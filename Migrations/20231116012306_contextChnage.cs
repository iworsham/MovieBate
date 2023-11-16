using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MovieBate.Migrations
{
    /// <inheritdoc />
    public partial class contextChnage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comments_movie_movie_id",
                table: "comments");

            migrationBuilder.DropTable(
                name: "movie");

            migrationBuilder.RenameColumn(
                name: "total_results",
                table: "movies",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "response",
                table: "movies",
                newName: "type");

            migrationBuilder.AddColumn<string>(
                name: "imdb_id",
                table: "movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "poster",
                table: "movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_movies_movie_id",
                table: "comments",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comments_movies_movie_id",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "imdb_id",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "poster",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "title",
                table: "movies");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "movies",
                newName: "total_results");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "movies",
                newName: "response");

            migrationBuilder.CreateTable(
                name: "movie",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    api_response_id = table.Column<int>(type: "integer", nullable: true),
                    imdb_id = table.Column<string>(type: "text", nullable: false),
                    poster = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    year = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_movie", x => x.id);
                    table.ForeignKey(
                        name: "fk_movie_movies_api_response_id",
                        column: x => x.api_response_id,
                        principalTable: "movies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_movie_api_response_id",
                table: "movie",
                column: "api_response_id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_movie_movie_id",
                table: "comments",
                column: "movie_id",
                principalTable: "movie",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
