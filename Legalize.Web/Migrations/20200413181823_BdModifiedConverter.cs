using Microsoft.EntityFrameworkCore.Migrations;

namespace Legalize.Web.Migrations
{
    public partial class BdModifiedConverter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDetails_Trips_Tripid",
                table: "TripDetails");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Trips",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Tripid",
                table: "TripDetails",
                newName: "TripId");

            migrationBuilder.RenameIndex(
                name: "IX_TripDetails_Tripid",
                table: "TripDetails",
                newName: "IX_TripDetails_TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetails_Trips_TripId",
                table: "TripDetails",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDetails_Trips_TripId",
                table: "TripDetails");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Trips",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TripId",
                table: "TripDetails",
                newName: "Tripid");

            migrationBuilder.RenameIndex(
                name: "IX_TripDetails_TripId",
                table: "TripDetails",
                newName: "IX_TripDetails_Tripid");

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetails_Trips_Tripid",
                table: "TripDetails",
                column: "Tripid",
                principalTable: "Trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
