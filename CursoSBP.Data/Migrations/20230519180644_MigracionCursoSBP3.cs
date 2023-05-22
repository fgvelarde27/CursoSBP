using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoSBP.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracionCursoSBP3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampusId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Campus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampusId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Campus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
