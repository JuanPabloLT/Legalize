using Microsoft.EntityFrameworkCore.Migrations;

namespace Legalize.Web.Migrations
{
    public partial class AddIndexOnEmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Legalizes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Legalizes_EmployeeId",
                table: "Legalizes",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Legalizes_EmployeeId",
                table: "Legalizes");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Legalizes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
