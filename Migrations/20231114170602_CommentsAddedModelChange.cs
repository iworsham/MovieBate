using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MovieBate.Migrations
{
    /// <inheritdoc />
    public partial class CommentsAddedModelChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "plot",
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
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "search",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    year = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    plot = table.Column<string>(type: "text", nullable: false),
                    movie_api_response_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_search", x => x.id);
                    table.ForeignKey(
                        name: "fk_search_movies_movie_api_response_id",
                        column: x => x.movie_api_response_id,
                        principalTable: "movies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_search_movie_api_response_id",
                table: "search",
                column: "movie_api_response_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "search");

            migrationBuilder.RenameColumn(
                name: "total_results",
                table: "movies",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "response",
                table: "movies",
                newName: "type");

            migrationBuilder.AddColumn<string>(
                name: "plot",
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
        }
    }
}
