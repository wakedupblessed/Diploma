﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.DbContext;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDatabaseContext))]
    [Migration("20240501110752_UpdateLanguageSkillsEntries")]
    partial class UpdateLanguageSkillsEntries
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Diploma.Domain.Candidate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Experience")
                        .HasColumnType("float");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("SalaryExpectation")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("Diploma.Domain.CandidateRelationships.CandidateCertificate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CertificateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("CertificateId");

                    b.ToTable("CandidateCertificates");
                });

            modelBuilder.Entity("Diploma.Domain.CandidateRelationships.CandidateLanguageSkill", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LanguageSkillId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("LanguageSkillId");

                    b.ToTable("CandidateLanguageSkills");
                });

            modelBuilder.Entity("Diploma.Domain.CandidateRelationships.CandidatePublication", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PublicationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("PublicationId");

                    b.ToTable("CandidatePublications");
                });

            modelBuilder.Entity("Diploma.Domain.CandidateRelationships.CandidateSkill", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("SkillId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("SkillId");

                    b.ToTable("CandidateSkills");
                });

            modelBuilder.Entity("Diploma.Domain.CandidateVacancy", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VacancyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("VacancyId");

                    b.ToTable("CandidateVacancies");
                });

            modelBuilder.Entity("Diploma.Domain.Features.Certificate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("Diploma.Domain.Features.Company", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Diploma.Domain.Features.LanguageSkill", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LanguageSkills");
                });

            modelBuilder.Entity("Diploma.Domain.Features.Location", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Diploma.Domain.Features.Publication", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Doi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JournalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfPublication")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("Diploma.Domain.Features.Skill", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Diploma.Domain.Vacancy", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExperienceYears")
                        .HasColumnType("int");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SalaryExpectation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("Diploma.Domain.VacancyRelationships.VacancyCertificate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CertificateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VacancyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CertificateId");

                    b.HasIndex("VacancyId");

                    b.ToTable("VacancyCertificates");
                });

            modelBuilder.Entity("Diploma.Domain.VacancyRelationships.VacancyLanguageSkill", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LanguageSkillId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("VacancyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageSkillId");

                    b.HasIndex("VacancyId");

                    b.ToTable("VacancyLanguageSkills");
                });

            modelBuilder.Entity("Diploma.Domain.VacancyRelationships.VacancyPublication", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PublicationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VacancyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PublicationId");

                    b.HasIndex("VacancyId");

                    b.ToTable("VacancyPublications");
                });

            modelBuilder.Entity("Diploma.Domain.VacancyRelationships.VacancySkill", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("SkillId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VacancyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("VacancyId");

                    b.ToTable("VacancySkills");
                });

            modelBuilder.Entity("Diploma.Domain.Candidate", b =>
                {
                    b.HasOne("Diploma.Domain.Features.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Diploma.Domain.CandidateRelationships.CandidateCertificate", b =>
                {
                    b.HasOne("Diploma.Domain.Candidate", "Candidate")
                        .WithMany("CandidateCertificates")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diploma.Domain.Features.Certificate", "Certificate")
                        .WithMany()
                        .HasForeignKey("CertificateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Certificate");
                });

            modelBuilder.Entity("Diploma.Domain.CandidateRelationships.CandidateLanguageSkill", b =>
                {
                    b.HasOne("Diploma.Domain.Candidate", "Candidate")
                        .WithMany("CandidateLanguageSkills")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diploma.Domain.Features.LanguageSkill", "LanguageSkill")
                        .WithMany()
                        .HasForeignKey("LanguageSkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("LanguageSkill");
                });

            modelBuilder.Entity("Diploma.Domain.CandidateRelationships.CandidatePublication", b =>
                {
                    b.HasOne("Diploma.Domain.Candidate", "Candidate")
                        .WithMany("CandidatePublications")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diploma.Domain.Features.Publication", "Publication")
                        .WithMany()
                        .HasForeignKey("PublicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Publication");
                });

            modelBuilder.Entity("Diploma.Domain.CandidateRelationships.CandidateSkill", b =>
                {
                    b.HasOne("Diploma.Domain.Candidate", "Candidate")
                        .WithMany("CandidateSkills")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diploma.Domain.Features.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Diploma.Domain.CandidateVacancy", b =>
                {
                    b.HasOne("Diploma.Domain.Candidate", "Candidate")
                        .WithMany("CandidateVacancies")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Diploma.Domain.Vacancy", "Vacancy")
                        .WithMany("CandidateVacancies")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Diploma.Domain.Features.Certificate", b =>
                {
                    b.HasOne("Diploma.Domain.Features.Company", "Company")
                        .WithMany("Certificates")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Diploma.Domain.Vacancy", b =>
                {
                    b.HasOne("Diploma.Domain.Features.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Diploma.Domain.VacancyRelationships.VacancyCertificate", b =>
                {
                    b.HasOne("Diploma.Domain.Features.Certificate", "Certificate")
                        .WithMany()
                        .HasForeignKey("CertificateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diploma.Domain.Vacancy", "Vacancy")
                        .WithMany("VacancyCertificates")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Certificate");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Diploma.Domain.VacancyRelationships.VacancyLanguageSkill", b =>
                {
                    b.HasOne("Diploma.Domain.Features.LanguageSkill", "LanguageSkill")
                        .WithMany()
                        .HasForeignKey("LanguageSkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diploma.Domain.Vacancy", "Vacancy")
                        .WithMany("VacancyLanguageSkills")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LanguageSkill");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Diploma.Domain.VacancyRelationships.VacancyPublication", b =>
                {
                    b.HasOne("Diploma.Domain.Features.Publication", "Publication")
                        .WithMany()
                        .HasForeignKey("PublicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diploma.Domain.Vacancy", "Vacancy")
                        .WithMany("VacancyPublications")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publication");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Diploma.Domain.VacancyRelationships.VacancySkill", b =>
                {
                    b.HasOne("Diploma.Domain.Features.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diploma.Domain.Vacancy", "Vacancy")
                        .WithMany("VacancySkills")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Diploma.Domain.Candidate", b =>
                {
                    b.Navigation("CandidateCertificates");

                    b.Navigation("CandidateLanguageSkills");

                    b.Navigation("CandidatePublications");

                    b.Navigation("CandidateSkills");

                    b.Navigation("CandidateVacancies");
                });

            modelBuilder.Entity("Diploma.Domain.Features.Company", b =>
                {
                    b.Navigation("Certificates");
                });

            modelBuilder.Entity("Diploma.Domain.Vacancy", b =>
                {
                    b.Navigation("CandidateVacancies");

                    b.Navigation("VacancyCertificates");

                    b.Navigation("VacancyLanguageSkills");

                    b.Navigation("VacancyPublications");

                    b.Navigation("VacancySkills");
                });
#pragma warning restore 612, 618
        }
    }
}
