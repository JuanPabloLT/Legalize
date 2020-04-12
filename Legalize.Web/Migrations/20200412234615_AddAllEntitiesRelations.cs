using Microsoft.EntityFrameworkCore.Migrations;

namespace Legalize.Web.Migrations
{
    public partial class AddAllEntitiesRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityEntity_CountryEntity_CountryId",
                table: "CityEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TripDetailEntity_ExpenseTypeEntity_ExpenseTypeId",
                table: "TripDetailEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TripDetailEntity_Trips_Tripid",
                table: "TripDetailEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_CityEntity_CityId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_UserEntity_UserId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripDetailEntity",
                table: "TripDetailEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseTypeEntity",
                table: "ExpenseTypeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryEntity",
                table: "CountryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityEntity",
                table: "CityEntity");

            migrationBuilder.RenameTable(
                name: "UserEntity",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TripDetailEntity",
                newName: "TripDetails");

            migrationBuilder.RenameTable(
                name: "ExpenseTypeEntity",
                newName: "ExpenseTypes");

            migrationBuilder.RenameTable(
                name: "CountryEntity",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "CityEntity",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_TripDetailEntity_Tripid",
                table: "TripDetails",
                newName: "IX_TripDetails_Tripid");

            migrationBuilder.RenameIndex(
                name: "IX_TripDetailEntity_ExpenseTypeId",
                table: "TripDetails",
                newName: "IX_TripDetails_ExpenseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CityEntity_CountryId",
                table: "Cities",
                newName: "IX_Cities_CountryId");

            migrationBuilder.AddColumn<int>(
                name: "LegalizeId",
                table: "Trips",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripDetails",
                table: "TripDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseTypes",
                table: "ExpenseTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_LegalizeId",
                table: "Trips",
                column: "LegalizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetails_ExpenseTypes_ExpenseTypeId",
                table: "TripDetails",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetails_Trips_Tripid",
                table: "TripDetails",
                column: "Tripid",
                principalTable: "Trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Cities_CityId",
                table: "Trips",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Legalizes_LegalizeId",
                table: "Trips",
                column: "LegalizeId",
                principalTable: "Legalizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Users_UserId",
                table: "Trips",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_TripDetails_ExpenseTypes_ExpenseTypeId",
                table: "TripDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TripDetails_Trips_Tripid",
                table: "TripDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Cities_CityId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Legalizes_LegalizeId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Users_UserId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_LegalizeId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripDetails",
                table: "TripDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseTypes",
                table: "ExpenseTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "LegalizeId",
                table: "Trips");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserEntity");

            migrationBuilder.RenameTable(
                name: "TripDetails",
                newName: "TripDetailEntity");

            migrationBuilder.RenameTable(
                name: "ExpenseTypes",
                newName: "ExpenseTypeEntity");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "CountryEntity");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "CityEntity");

            migrationBuilder.RenameIndex(
                name: "IX_TripDetails_Tripid",
                table: "TripDetailEntity",
                newName: "IX_TripDetailEntity_Tripid");

            migrationBuilder.RenameIndex(
                name: "IX_TripDetails_ExpenseTypeId",
                table: "TripDetailEntity",
                newName: "IX_TripDetailEntity_ExpenseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "CityEntity",
                newName: "IX_CityEntity_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripDetailEntity",
                table: "TripDetailEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseTypeEntity",
                table: "ExpenseTypeEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryEntity",
                table: "CountryEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityEntity",
                table: "CityEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CityEntity_CountryEntity_CountryId",
                table: "CityEntity",
                column: "CountryId",
                principalTable: "CountryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetailEntity_ExpenseTypeEntity_ExpenseTypeId",
                table: "TripDetailEntity",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetailEntity_Trips_Tripid",
                table: "TripDetailEntity",
                column: "Tripid",
                principalTable: "Trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_CityEntity_CityId",
                table: "Trips",
                column: "CityId",
                principalTable: "CityEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_UserEntity_UserId",
                table: "Trips",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
