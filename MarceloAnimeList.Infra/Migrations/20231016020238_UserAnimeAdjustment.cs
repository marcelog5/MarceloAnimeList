using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarceloAnimeList.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UserAnimeAdjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Season",
                table: "UserAnime");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Anime",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Anime");

            migrationBuilder.AddColumn<int>(
                name: "Season",
                table: "UserAnime",
                type: "int",
                nullable: true);
        }
    }
}
