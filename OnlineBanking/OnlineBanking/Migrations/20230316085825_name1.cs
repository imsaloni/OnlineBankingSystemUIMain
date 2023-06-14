using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBanking.Migrations
{
    public partial class name1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Admins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
