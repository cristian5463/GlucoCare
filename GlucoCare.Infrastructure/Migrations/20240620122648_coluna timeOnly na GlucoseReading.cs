using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlucoCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class colunatimeOnlynaGlucoseReading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeOnly",
                table: "GlucoseReading",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeOnly",
                table: "GlucoseReading");
        }
    }
}
