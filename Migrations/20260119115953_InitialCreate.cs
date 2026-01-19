using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMarket.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marque = table.Column<string>(type: "TEXT", nullable: false),
                    Modele = table.Column<string>(type: "TEXT", nullable: false),
                    Annee = table.Column<int>(type: "INTEGER", nullable: false),
                    Kilometrage = table.Column<int>(type: "INTEGER", nullable: false),
                    Prix = table.Column<decimal>(type: "TEXT", nullable: false),
                    PhotoPath = table.Column<string>(type: "TEXT", nullable: false),
                    Verifie = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Annonces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titre = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Statut = table.Column<string>(type: "TEXT", nullable: false),
                    DatePublication = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VehiculeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SellerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annonces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annonces_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annonces_Vehicules_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehiculeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpertId = table.Column<int>(type: "INTEGER", nullable: false),
                    Approuve = table.Column<bool>(type: "INTEGER", nullable: false),
                    Rapport = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verification_Users_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verification_Vehicules_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Annonces_SellerId",
                table: "Annonces",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Annonces_VehiculeId",
                table: "Annonces",
                column: "VehiculeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verification_ExpertId",
                table: "Verification",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Verification_VehiculeId",
                table: "Verification",
                column: "VehiculeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annonces");

            migrationBuilder.DropTable(
                name: "Verification");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vehicules");
        }
    }
}
