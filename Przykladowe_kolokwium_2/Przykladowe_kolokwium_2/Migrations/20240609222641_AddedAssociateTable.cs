using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Przykladowe_kolokwium_2.Migrations
{
    /// <inheritdoc />
    public partial class AddedAssociateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuzykUtwor");

            migrationBuilder.CreateTable(
                name: "WykonawcaUtworu",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false),
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WykonawcaUtworu", x => new { x.IdMuzyk, x.IdUtwor });
                    table.ForeignKey(
                        name: "FK_WykonawcaUtworu_Muzyk_IdMuzyk",
                        column: x => x.IdMuzyk,
                        principalTable: "Muzyk",
                        principalColumn: "IdMuzyk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WykonawcaUtworu_Utwor_IdUtwor",
                        column: x => x.IdUtwor,
                        principalTable: "Utwor",
                        principalColumn: "IdUtwor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WykonawcaUtworu_IdUtwor",
                table: "WykonawcaUtworu",
                column: "IdUtwor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WykonawcaUtworu");

            migrationBuilder.CreateTable(
                name: "MuzykUtwor",
                columns: table => new
                {
                    MuzycyIdMuzyk = table.Column<int>(type: "int", nullable: false),
                    UtworyIdUtwor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuzykUtwor", x => new { x.MuzycyIdMuzyk, x.UtworyIdUtwor });
                    table.ForeignKey(
                        name: "FK_MuzykUtwor_Muzyk_MuzycyIdMuzyk",
                        column: x => x.MuzycyIdMuzyk,
                        principalTable: "Muzyk",
                        principalColumn: "IdMuzyk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuzykUtwor_Utwor_UtworyIdUtwor",
                        column: x => x.UtworyIdUtwor,
                        principalTable: "Utwor",
                        principalColumn: "IdUtwor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MuzykUtwor_UtworyIdUtwor",
                table: "MuzykUtwor",
                column: "UtworyIdUtwor");
        }
    }
}
