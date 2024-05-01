using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageSkills",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JournalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfPublication = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryExpectation = table.Column<double>(type: "float", nullable: false),
                    Experience = table.Column<double>(type: "float", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryExpectation = table.Column<int>(type: "int", nullable: false),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacancies_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateCertificates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CertificateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateCertificates_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateCertificates_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateLanguageSkills",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageSkillId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateLanguageSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateLanguageSkills_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateLanguageSkills_LanguageSkills_LanguageSkillId",
                        column: x => x.LanguageSkillId,
                        principalTable: "LanguageSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidatePublications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PublicationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatePublications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatePublications_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatePublications_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateSkills",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SkillId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateSkills_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateVacancies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VacancyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateVacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateVacancies_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidateVacancies_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VacancyCertificates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CertificateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VacancyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyCertificates_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyCertificates_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancyLanguageSkills",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageSkillId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VacancyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyLanguageSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyLanguageSkills_LanguageSkills_LanguageSkillId",
                        column: x => x.LanguageSkillId,
                        principalTable: "LanguageSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyLanguageSkills_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancyPublications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PublicationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VacancyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyPublications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyPublications_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyPublications_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancySkills",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SkillId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    VacancyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancySkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancySkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancySkills_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCertificates_CandidateId",
                table: "CandidateCertificates",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCertificates_CertificateId",
                table: "CandidateCertificates",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLanguageSkills_CandidateId",
                table: "CandidateLanguageSkills",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLanguageSkills_LanguageSkillId",
                table: "CandidateLanguageSkills",
                column: "LanguageSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePublications_CandidateId",
                table: "CandidatePublications",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePublications_PublicationId",
                table: "CandidatePublications",
                column: "PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_LocationId",
                table: "Candidates",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkills_CandidateId",
                table: "CandidateSkills",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkills_SkillId",
                table: "CandidateSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateVacancies_CandidateId",
                table: "CandidateVacancies",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateVacancies_VacancyId",
                table: "CandidateVacancies",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CompanyId",
                table: "Certificates",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_LocationId",
                table: "Vacancies",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyCertificates_CertificateId",
                table: "VacancyCertificates",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyCertificates_VacancyId",
                table: "VacancyCertificates",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyLanguageSkills_LanguageSkillId",
                table: "VacancyLanguageSkills",
                column: "LanguageSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyLanguageSkills_VacancyId",
                table: "VacancyLanguageSkills",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyPublications_PublicationId",
                table: "VacancyPublications",
                column: "PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyPublications_VacancyId",
                table: "VacancyPublications",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancySkills_SkillId",
                table: "VacancySkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancySkills_VacancyId",
                table: "VacancySkills",
                column: "VacancyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateCertificates");

            migrationBuilder.DropTable(
                name: "CandidateLanguageSkills");

            migrationBuilder.DropTable(
                name: "CandidatePublications");

            migrationBuilder.DropTable(
                name: "CandidateSkills");

            migrationBuilder.DropTable(
                name: "CandidateVacancies");

            migrationBuilder.DropTable(
                name: "VacancyCertificates");

            migrationBuilder.DropTable(
                name: "VacancyLanguageSkills");

            migrationBuilder.DropTable(
                name: "VacancyPublications");

            migrationBuilder.DropTable(
                name: "VacancySkills");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "LanguageSkills");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
