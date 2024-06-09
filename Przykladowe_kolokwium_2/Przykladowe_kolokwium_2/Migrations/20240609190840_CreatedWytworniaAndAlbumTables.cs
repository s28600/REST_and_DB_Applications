using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Przykladowe_kolokwium_2.Migrations
{
    /// <inheritdoc />
    public partial class CreatedWytworniaAndAlbumTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wytwornia",
                columns: table => new
                {
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wytwornia", x => x.IdWytwornia);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaAlbumu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DataWydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "Wytwornia_Album",
                        column: x => x.IdWytwornia,
                        principalTable: "Wytwornia",
                        principalColumn: "IdWytwornia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_IdWytwornia",
                table: "Albums",
                column: "IdWytwornia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Wytwornia");
        }
    }
}
