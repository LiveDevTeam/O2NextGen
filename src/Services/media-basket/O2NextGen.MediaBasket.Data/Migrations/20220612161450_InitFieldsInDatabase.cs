using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace O2NextGen.MediaBasket.Data.Migrations
{
    public partial class InitFieldsInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Media",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Media",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Media",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Media",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtType",
                table: "Media",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Media",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MediaType",
                table: "Media",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalName",
                table: "Media",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Media",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Media",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Media",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "ExtType",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "MediaType",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "OriginalName",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Media");
        }
    }
}
