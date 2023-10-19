using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laul.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SongAddProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Songs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Storage",
                table: "Songs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Storage",
                table: "Songs");
        }
    }
}
