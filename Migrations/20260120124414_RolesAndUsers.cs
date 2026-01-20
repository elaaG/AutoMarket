using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMarket.Migrations
{
    /// <inheritdoc />
    public partial class RolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verification_Annonces_AnnonceId",
                table: "Verification");

            migrationBuilder.DropForeignKey(
                name: "FK_Verification_AspNetUsers_ExpertId",
                table: "Verification");

            migrationBuilder.DropForeignKey(
                name: "FK_Verification_Vehicules_VehiculeId",
                table: "Verification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Verification",
                table: "Verification");

            migrationBuilder.RenameTable(
                name: "Verification",
                newName: "Verifications");

            migrationBuilder.RenameIndex(
                name: "IX_Verification_VehiculeId",
                table: "Verifications",
                newName: "IX_Verifications_VehiculeId");

            migrationBuilder.RenameIndex(
                name: "IX_Verification_ExpertId",
                table: "Verifications",
                newName: "IX_Verifications_ExpertId");

            migrationBuilder.RenameIndex(
                name: "IX_Verification_AnnonceId",
                table: "Verifications",
                newName: "IX_Verifications_AnnonceId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verifications",
                table: "Verifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Verifications_Annonces_AnnonceId",
                table: "Verifications",
                column: "AnnonceId",
                principalTable: "Annonces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Verifications_AspNetUsers_ExpertId",
                table: "Verifications",
                column: "ExpertId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Verifications_Vehicules_VehiculeId",
                table: "Verifications",
                column: "VehiculeId",
                principalTable: "Vehicules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verifications_Annonces_AnnonceId",
                table: "Verifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Verifications_AspNetUsers_ExpertId",
                table: "Verifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Verifications_Vehicules_VehiculeId",
                table: "Verifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Verifications",
                table: "Verifications");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Verifications",
                newName: "Verification");

            migrationBuilder.RenameIndex(
                name: "IX_Verifications_VehiculeId",
                table: "Verification",
                newName: "IX_Verification_VehiculeId");

            migrationBuilder.RenameIndex(
                name: "IX_Verifications_ExpertId",
                table: "Verification",
                newName: "IX_Verification_ExpertId");

            migrationBuilder.RenameIndex(
                name: "IX_Verifications_AnnonceId",
                table: "Verification",
                newName: "IX_Verification_AnnonceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verification",
                table: "Verification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Verification_Annonces_AnnonceId",
                table: "Verification",
                column: "AnnonceId",
                principalTable: "Annonces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Verification_AspNetUsers_ExpertId",
                table: "Verification",
                column: "ExpertId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Verification_Vehicules_VehiculeId",
                table: "Verification",
                column: "VehiculeId",
                principalTable: "Vehicules",
                principalColumn: "Id");
        }
    }
}
