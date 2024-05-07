using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEducationFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequiredEducationId",
                table: "Vacancies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationId",
                table: "Candidates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SpecificFieldOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredEducationLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_RequiredEducationId",
                table: "Vacancies",
                column: "RequiredEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_EducationId",
                table: "Candidates",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Educations_EducationId",
                table: "Candidates",
                column: "EducationId",
                principalTable: "Educations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Educations_RequiredEducationId",
                table: "Vacancies",
                column: "RequiredEducationId",
                principalTable: "Educations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Educations_EducationId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Educations_RequiredEducationId",
                table: "Vacancies");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_RequiredEducationId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_EducationId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "RequiredEducationId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "Candidates");
        }
    }
}
