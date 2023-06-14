using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBanking.Migrations
{
    public partial class AccountDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Userid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AadharNumber = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    AnnualIncome = table.Column<string>(nullable: true),
                    pwd = table.Column<string>(nullable: true),
                    MemberSince = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Userid);
                });

            migrationBuilder.CreateTable(
                name: "AccountDetailss",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(nullable: false),
                    Balance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDetailss", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_AccountDetailss_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "Userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountDetailss_Userid",
                table: "AccountDetailss",
                column: "Userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountDetailss");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
