using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Przykladowe_kolokwium_2.Migrations
{
    /// <inheritdoc />
    public partial class EditedWytworniaAndAlbumTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Album");

            migrationBuilder.RenameColumn(
                name: "IdWytwornia",
                table: "Album",
                newName: "WytworniaIdWytwornia");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_IdWytwornia",
                table: "Album",
                newName: "IX_Album_WytworniaIdWytwornia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "IdAlbum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "Albums");

            migrationBuilder.RenameColumn(
                name: "WytworniaIdWytwornia",
                table: "Albums",
                newName: "IdWytwornia");

            migrationBuilder.RenameIndex(
                name: "IX_Album_WytworniaIdWytwornia",
                table: "Albums",
                newName: "IX_Albums_IdWytwornia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "IdAlbum");
        }
    }
}
