using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace plattformpartizipativesneophytenmanagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FarmerHelpRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerUserId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    WorkVolume = table.Column<int>(type: "int", nullable: false),
                    NumberOfHelpers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerHelpRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmerHelpRequests_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmerHelpRequests_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HelperHelpOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerUserId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    DistanceFromLocation = table.Column<double>(type: "float", nullable: false),
                    WorkVolume = table.Column<int>(type: "int", nullable: false),
                    NumberOfHelpers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelperHelpOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelperHelpOffers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HelperHelpOffers_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvasiveSpeciesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmerHelpRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvasiveSpeciesTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvasiveSpeciesTypes_FarmerHelpRequests_FarmerHelpRequestId",
                        column: x => x.FarmerHelpRequestId,
                        principalTable: "FarmerHelpRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Negotiations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InitiatedByUserId = table.Column<int>(type: "int", nullable: false),
                    FarmerHelpRequestId = table.Column<int>(type: "int", nullable: false),
                    HelperHelpOfferId = table.Column<int>(type: "int", nullable: false),
                    FarmerStatus = table.Column<int>(type: "int", nullable: false),
                    HelperStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negotiations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Negotiations_FarmerHelpRequests_FarmerHelpRequestId",
                        column: x => x.FarmerHelpRequestId,
                        principalTable: "FarmerHelpRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Negotiations_HelperHelpOffers_HelperHelpOfferId",
                        column: x => x.HelperHelpOfferId,
                        principalTable: "HelperHelpOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Negotiations_Users_InitiatedByUserId",
                        column: x => x.InitiatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FarmerHelpRequests_LocationId",
                table: "FarmerHelpRequests",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerHelpRequests_OwnerUserId",
                table: "FarmerHelpRequests",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HelperHelpOffers_LocationId",
                table: "HelperHelpOffers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HelperHelpOffers_OwnerUserId",
                table: "HelperHelpOffers",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvasiveSpeciesTypes_FarmerHelpRequestId",
                table: "InvasiveSpeciesTypes",
                column: "FarmerHelpRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Negotiations_FarmerHelpRequestId",
                table: "Negotiations",
                column: "FarmerHelpRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Negotiations_HelperHelpOfferId",
                table: "Negotiations",
                column: "HelperHelpOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Negotiations_InitiatedByUserId",
                table: "Negotiations",
                column: "InitiatedByUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvasiveSpeciesTypes");

            migrationBuilder.DropTable(
                name: "Negotiations");

            migrationBuilder.DropTable(
                name: "FarmerHelpRequests");

            migrationBuilder.DropTable(
                name: "HelperHelpOffers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
