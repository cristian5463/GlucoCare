using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlucoCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_column_time : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadingTime",
                table: "GlucoseReading");

            migrationBuilder.RenameColumn(
                name: "ReadingDate",
                table: "GlucoseReading",
                newName: "ReadingDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReadingDateTime",
                table: "GlucoseReading",
                newName: "ReadingDate");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ReadingTime",
                table: "GlucoseReading",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
