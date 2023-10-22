using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laul.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class configureSongAlbum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Albums");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Songs",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Albums",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Albums");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
