using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace O2NextGen.CertificateManagement.Infrastructure.Data.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageInfos");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.CreateTable(
                name: "CategoryEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorySeries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityCertificates = table.Column<int>(type: "int", nullable: false),
                    QuantityPublishCode = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeLifeInDays = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<long>(type: "bigint", nullable: false),
                    AddedDate = table.Column<long>(type: "bigint", nullable: false),
                    DeletedDate = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificateEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OwnerAccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiredDate = table.Column<long>(type: "bigint", nullable: false),
                    PublishDate = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryEntityId = table.Column<long>(type: "bigint", nullable: true),
                    Lock = table.Column<bool>(type: "bit", nullable: false),
                    LockedDate = table.Column<long>(type: "bigint", nullable: false),
                    LockInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<long>(type: "bigint", nullable: false),
                    AddedDate = table.Column<long>(type: "bigint", nullable: false),
                    DeletedDate = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificateEntity_CategoryEntity_CategoryEntityId",
                        column: x => x.CategoryEntityId,
                        principalTable: "CategoryEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LanguageInfoEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CertificateId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<long>(type: "bigint", nullable: false),
                    AddedDate = table.Column<long>(type: "bigint", nullable: false),
                    DeletedDate = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageInfoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageInfoEntity_CertificateEntity_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "CertificateEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CertificateEntity_CategoryEntityId",
                table: "CertificateEntity",
                column: "CategoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageInfoEntity_CertificateId",
                table: "LanguageInfoEntity",
                column: "CertificateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageInfoEntity");

            migrationBuilder.DropTable(
                name: "CertificateEntity");

            migrationBuilder.DropTable(
                name: "CategoryEntity");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    AddedDate = table.Column<long>(type: "bigint", nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorySeries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedDate = table.Column<long>(type: "bigint", nullable: false),
                    QuantityCertificates = table.Column<int>(type: "int", nullable: false),
                    QuantityPublishCode = table.Column<int>(type: "int", nullable: false),
                    TimeLifeInDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    AddedDate = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<long>(type: "bigint", nullable: true),
                    ExpiredDate = table.Column<long>(type: "bigint", nullable: false),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    Lock = table.Column<bool>(type: "bit", nullable: false),
                    LockInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LockedDate = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<long>(type: "bigint", nullable: false),
                    OwnerAccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificate_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CertificateId = table.Column<long>(type: "bigint", nullable: false),
                    AddedDate = table.Column<long>(type: "bigint", nullable: false),
                    DeletedDate = table.Column<long>(type: "bigint", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageInfos_Certificate_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_CategoryId",
                table: "Certificate",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageInfos_CertificateId",
                table: "LanguageInfos",
                column: "CertificateId");
        }
    }
}
