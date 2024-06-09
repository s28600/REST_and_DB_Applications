using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Przykladowe_kolokwium_2.Migrations
{
    /// <inheritdoc />
    public partial class AddedUtworAndMuzyk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muzyk",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Pseudonim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muzyk", x => x.IdMuzyk);
                });

            migrationBuilder.CreateTable(
                name: "Utwor",
                columns: table => new
                {
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUtworu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CzasTrwania = table.Column<float>(type: "real", nullable: false),
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utwor", x => x.IdUtwor);
                    table.ForeignKey(
                        name: "FK_Utwor_Album_IdAlbum",
                        column: x => x.IdAlbum,
                        principalTable: "Album",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Utwor_IdAlbum",
                table: "Utwor",
                column: "IdAlbum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuzykUtwor");

            migrationBuilder.DropTable(
                name: "Muzyk");

            migrationBuilder.DropTable(
                name: "Utwor");
        }
    }
}
