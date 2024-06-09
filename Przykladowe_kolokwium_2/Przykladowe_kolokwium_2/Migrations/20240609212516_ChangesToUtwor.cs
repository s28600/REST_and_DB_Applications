using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Przykladowe_kolokwium_2.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToUtwor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utwor_Album_IdAlbum",
                table: "Utwor");

            migrationBuilder.AlterColumn<int>(
                name: "IdAlbum",
                table: "Utwor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Utwor_Album_IdAlbum",
                table: "Utwor",
                column: "IdAlbum",
                principalTable: "Album",
                principalColumn: "IdAlbum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utwor_Album_IdAlbum",
                table: "Utwor");

            migrationBuilder.AlterColumn<int>(
                name: "IdAlbum",
                table: "Utwor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Utwor_Album_IdAlbum",
                table: "Utwor",
                column: "IdAlbum",
                principalTable: "Album",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
