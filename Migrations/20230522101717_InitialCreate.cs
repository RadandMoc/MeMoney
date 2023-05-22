using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeMoney.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    IdCompany1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Person1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIP1 = table.Column<int>(type: "int", nullable: false),
                    KRS1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.IdCompany1);
                });

            migrationBuilder.CreateTable(
                name: "Mem",
                columns: table => new
                {
                    IdMem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem", x => x.IdMem);
                });

            migrationBuilder.CreateTable(
                name: "MemAuthor",
                columns: table => new
                {
                    IdMemAuthor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemAuthor", x => x.IdMemAuthor);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyIdCompany1 = table.Column<int>(type: "int", nullable: false),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdditionalSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IfPaid = table.Column<bool>(type: "bit", nullable: false),
                    MaximalSalary1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferMem",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    MemId = table.Column<int>(type: "int", nullable: false),
                    OfferMemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferMem", x => new { x.MemId, x.OfferId });
                    table.ForeignKey(
                        name: "FK_OfferMem_Mem_MemId",
                        column: x => x.MemId,
                        principalTable: "Mem",
                        principalColumn: "IdMem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferMem_Offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferMemAuthor",
                columns: table => new
                {
                    IdMemAuthor = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    OfferMemAuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferMemAuthor", x => new { x.IdMemAuthor, x.OfferId });
                    table.ForeignKey(
                        name: "FK_OfferMemAuthor_MemAuthor_IdMemAuthor",
                        column: x => x.IdMemAuthor,
                        principalTable: "MemAuthor",
                        principalColumn: "IdMemAuthor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferMemAuthor_Offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferMem_OfferId",
                table: "OfferMem",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferMemAuthor_OfferId",
                table: "OfferMemAuthor",
                column: "OfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "OfferMem");

            migrationBuilder.DropTable(
                name: "OfferMemAuthor");

            migrationBuilder.DropTable(
                name: "Mem");

            migrationBuilder.DropTable(
                name: "MemAuthor");

            migrationBuilder.DropTable(
                name: "Offer");
        }
    }
}
