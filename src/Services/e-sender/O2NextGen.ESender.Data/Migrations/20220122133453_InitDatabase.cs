using Microsoft.EntityFrameworkCore.Migrations;

namespace O2NextGen.ESender.Data.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "mailrequest_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "MailRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailRequest", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailRequest");

            migrationBuilder.DropSequence(
                name: "mailrequest_hilo");
        }
    }
}
