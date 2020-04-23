using Microsoft.EntityFrameworkCore.Migrations;

namespace Legalize.Web.Migrations
{
    public partial class ModifyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Legalizes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalAmount",
                table: "Legalizes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
