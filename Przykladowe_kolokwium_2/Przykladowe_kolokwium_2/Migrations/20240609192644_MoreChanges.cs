using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Przykladowe_kolokwium_2.Migrations
{
    /// <inheritdoc />
    public partial class MoreChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WytworniaIdWytwornia",
                table: "Album",
                newName: "IdWytwornia");

            migrationBuilder.RenameIndex(
                name: "IX_Album_WytworniaIdWytwornia",
                table: "Album",
                newName: "IX_Album_IdWytwornia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdWytwornia",
                table: "Album",
                newName: "WytworniaIdWytwornia");

            migrationBuilder.RenameIndex(
                name: "IX_Album_IdWytwornia",
                table: "Album",
                newName: "IX_Album_WytworniaIdWytwornia");
        }
    }
}
