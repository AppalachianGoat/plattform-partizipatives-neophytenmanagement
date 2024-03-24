using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                name: "FarmerHelpRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    WorkVolume = table.Column<int>(type: "integer", nullable: false),
                    NumberOfHelpers = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerHelpRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HelperHelpOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    DistanceFromLocation = table.Column<double>(type: "double precision", nullable: false),
                    WorkVolume = table.Column<int>(type: "integer", nullable: false),
                    NumberOfHelpers = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelperHelpOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvasiveSpeciesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    FarmerHelpRequestId = table.Column<int>(type: "integer", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InitiatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    FarmerHelpRequestId = table.Column<int>(type: "integer", nullable: false),
                    HelperHelpOfferId = table.Column<int>(type: "integer", nullable: false),
                    FarmerStatus = table.Column<int>(type: "integer", nullable: false),
                    HelperStatus = table.Column<int>(type: "integer", nullable: false)
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
                name: "Users");
        }
    }
}
