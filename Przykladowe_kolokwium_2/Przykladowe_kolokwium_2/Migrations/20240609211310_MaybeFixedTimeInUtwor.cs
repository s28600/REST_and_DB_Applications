using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Przykladowe_kolokwium_2.Migrations
{
    /// <inheritdoc />
    public partial class MaybeFixedTimeInUtwor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "CzasTrwania",
                table: "Utwor",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "CzasTrwania",
                table: "Utwor",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
