using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlucoCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class secondinsuluin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTypeInsulinSecond",
                table: "GlucoseReading",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsulinDoseSecond",
                table: "GlucoseReading",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTypeInsulinSecond",
                table: "GlucoseReading");

            migrationBuilder.DropColumn(
                name: "InsulinDoseSecond",
                table: "GlucoseReading");
        }
    }
}
