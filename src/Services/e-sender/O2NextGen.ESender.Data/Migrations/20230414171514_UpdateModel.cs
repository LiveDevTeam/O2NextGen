using Microsoft.EntityFrameworkCore.Migrations;

namespace O2NextGen.ESender.Data.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AddedDate",
                table: "MailRequest",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DeletedDate",
                table: "MailRequest",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MailRequest",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedDate",
                table: "MailRequest",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "MailRequest");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "MailRequest");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MailRequest");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "MailRequest");
        }
    }
}
