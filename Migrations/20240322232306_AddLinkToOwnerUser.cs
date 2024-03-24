using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace plattformpartizipativesneophytenmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkToOwnerUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "HelperHelpOffers",
                newName: "OwnerUserId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "FarmerHelpRequests",
                newName: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HelperHelpOffers_OwnerUserId",
                table: "HelperHelpOffers",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerHelpRequests_OwnerUserId",
                table: "FarmerHelpRequests",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerHelpRequests_Users_OwnerUserId",
                table: "FarmerHelpRequests",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HelperHelpOffers_Users_OwnerUserId",
                table: "HelperHelpOffers",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmerHelpRequests_Users_OwnerUserId",
                table: "FarmerHelpRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_HelperHelpOffers_Users_OwnerUserId",
                table: "HelperHelpOffers");

            migrationBuilder.DropIndex(
                name: "IX_HelperHelpOffers_OwnerUserId",
                table: "HelperHelpOffers");

            migrationBuilder.DropIndex(
                name: "IX_FarmerHelpRequests_OwnerUserId",
                table: "FarmerHelpRequests");

            migrationBuilder.RenameColumn(
                name: "OwnerUserId",
                table: "HelperHelpOffers",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "OwnerUserId",
                table: "FarmerHelpRequests",
                newName: "OwnerId");
        }
    }
}
