using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLanguageSkillsEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "LanguageSkills");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "VacancyLanguageSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "CandidateLanguageSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "VacancyLanguageSkills");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "CandidateLanguageSkills");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "LanguageSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
