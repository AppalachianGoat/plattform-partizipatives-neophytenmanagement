using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace plattformpartizipativesneophytenmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddDatesAndEnhancedLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "HelperHelpOffers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "FarmerHelpRequests");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "HelperHelpOffers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "HelperHelpOffers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "HelperHelpOffers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "FarmerHelpRequests",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "FarmerHelpRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "FarmerHelpRequests",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationString = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HelperHelpOffers_LocationId",
                table: "HelperHelpOffers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerHelpRequests_LocationId",
                table: "FarmerHelpRequests",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerHelpRequests_Locations_LocationId",
                table: "FarmerHelpRequests",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HelperHelpOffers_Locations_LocationId",
                table: "HelperHelpOffers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmerHelpRequests_Locations_LocationId",
                table: "FarmerHelpRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_HelperHelpOffers_Locations_LocationId",
                table: "HelperHelpOffers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_HelperHelpOffers_LocationId",
                table: "HelperHelpOffers");

            migrationBuilder.DropIndex(
                name: "IX_FarmerHelpRequests_LocationId",
                table: "FarmerHelpRequests");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "HelperHelpOffers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "HelperHelpOffers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "HelperHelpOffers");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "FarmerHelpRequests");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "FarmerHelpRequests");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "FarmerHelpRequests");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "HelperHelpOffers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "FarmerHelpRequests",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
