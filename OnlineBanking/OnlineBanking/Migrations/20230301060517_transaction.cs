using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBanking.Migrations
{
    public partial class transaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactionss",
                columns: table => new
                {
                    Transactionid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(nullable: false),
                    payeeAccountNo = table.Column<int>(nullable: false),
                    TransationAmount = table.Column<int>(nullable: false),
                    TransactionType = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactionss", x => x.Transactionid);
                    table.ForeignKey(
                        name: "FK_Transactionss_AccountDetailss_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "AccountDetailss",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactionss_AccountNumber",
                table: "Transactionss",
                column: "AccountNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactionss");
        }
    }
}
