using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GlucoCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableInsulin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insulin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameInsulin = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IndividualApplication = table.Column<bool>(type: "boolean", nullable: false),
                    TypesInsulin = table.Column<int[]>(type: "integer[]", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insulin", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insulin");
        }
    }
}
