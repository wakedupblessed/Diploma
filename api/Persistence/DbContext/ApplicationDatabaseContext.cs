using Diploma.Domain;
using Diploma.Domain.CandidateRelationships;
using Diploma.Domain.Features;
using Diploma.Domain.VacancyRelationships;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DbContext;

public class ApplicationDatabaseContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) 
        : base(options)
    {
    }

    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }
    public DbSet<CandidateVacancy> CandidateVacancies { get; set; }

    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<LanguageSkill> LanguageSkills { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Publication> Publications { get; set; }
    public DbSet<Skill> Skills { get; set; }

    public DbSet<CandidateCertificate> CandidateCertificates { get; set; }
    public DbSet<CandidateLanguageSkill> CandidateLanguageSkills { get; set; }
    public DbSet<CandidatePublication> CandidatePublications { get; set; }
    public DbSet<CandidateSkill> CandidateSkills { get; set; }

    public DbSet<VacancyCertificate> VacancyCertificates { get; set; }
    public DbSet<VacancyLanguageSkill> VacancyLanguageSkills { get; set; }
    public DbSet<VacancyPublication> VacancyPublications { get; set; }
    public DbSet<VacancySkill> VacancySkills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigurePrimaryKeys(modelBuilder);

        ConfigureRelationships(modelBuilder);
    }

    private static void ConfigurePrimaryKeys(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vacancy>().HasKey(v => v.Id);
        modelBuilder.Entity<Candidate>().HasKey(e => e.Id);

        modelBuilder.Entity<CandidateVacancy>().HasKey(cv => cv.Id);

        modelBuilder.Entity<Location>().HasKey(l => l.Id);
        modelBuilder.Entity<Publication>().HasKey(p => p.Id);
        modelBuilder.Entity<Skill>().HasKey(s => s.Id);
        modelBuilder.Entity<Certificate>().HasKey(c => c.Id);
        modelBuilder.Entity<Company>().HasKey(c => c.Id);
        modelBuilder.Entity<LanguageSkill>().HasKey(ls => ls.Id);

        modelBuilder.Entity<CandidateCertificate>().HasKey(ec => ec.Id);
        modelBuilder.Entity<CandidateLanguageSkill>().HasKey(els => els.Id);
        modelBuilder.Entity<CandidatePublication>().HasKey(ep => ep.Id);
        modelBuilder.Entity<CandidateSkill>().HasKey(es => es.Id);

        modelBuilder.Entity<VacancyCertificate>().HasKey(vc => vc.Id);
        modelBuilder.Entity<VacancyLanguageSkill>().HasKey(vls => vls.Id);
        modelBuilder.Entity<VacancyPublication>().HasKey(vp => vp.Id);
        modelBuilder.Entity<VacancySkill>().HasKey(vs => vs.Id);
    }

    private static void ConfigureRelationships(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CandidateVacancy>()
            .HasOne(cv => cv.Candidate)
            .WithMany(c => c.CandidateVacancies)
            .HasForeignKey(cv => cv.CandidateId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CandidateVacancy>()
            .HasOne(cv => cv.Vacancy)
            .WithMany(v => v.CandidateVacancies)
            .HasForeignKey(cv => cv.VacancyId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Company>()
            .HasMany(c => c.Certificates)
            .WithOne(c => c.Company)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        ConfigureCandidateRelationships(modelBuilder);

        ConfigureVacancyRelationships(modelBuilder);
    }

    private static void ConfigureVacancyRelationships(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vacancy>()
            .HasOne(v => v.Location)
            .WithMany()
            .HasForeignKey(v => v.LocationId);

        modelBuilder.Entity<Vacancy>()
            .HasOne(v => v.RequiredEducation);
        
        modelBuilder.Entity<Vacancy>()
            .HasMany(v => v.VacancySkills)
            .WithOne(vs => vs.Vacancy)
            .HasForeignKey(vs => vs.VacancyId);
        
        modelBuilder.Entity<VacancySkill>()
            .HasOne(vs => vs.Skill)
            .WithMany()
            .HasForeignKey(vs => vs.SkillId);

        modelBuilder.Entity<Vacancy>()
            .HasMany(v => v.VacancyCertificates)
            .WithOne(vc => vc.Vacancy)
            .HasForeignKey(vc => vc.VacancyId);

        modelBuilder.Entity<VacancyCertificate>()
            .HasOne(vc => vc.Certificate)
            .WithMany()
            .HasForeignKey(vc => vc.CertificateId);

        modelBuilder.Entity<Vacancy>()
            .HasMany(v => v.VacancyLanguageSkills)
            .WithOne(vls => vls.Vacancy)
            .HasForeignKey(vls => vls.VacancyId);

        modelBuilder.Entity<VacancyLanguageSkill>()
            .HasOne(vls => vls.LanguageSkill)
            .WithMany()
            .HasForeignKey(vls => vls.LanguageSkillId);

        modelBuilder.Entity<VacancyPublication>()
            .HasOne(vp => vp.Publication)
            .WithMany()
            .HasForeignKey(vp => vp.PublicationId);
    }
    
    private static void ConfigureCandidateRelationships(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>()
            .HasOne(e => e.Location)
            .WithMany()
            .HasForeignKey(e => e.LocationId);
        
        modelBuilder.Entity<Candidate>()
            .HasOne(v => v.Education);
        
        modelBuilder.Entity<Candidate>()
            .HasMany(e => e.CandidateSkills)
            .WithOne(es => es.Candidate)
            .HasForeignKey(es => es.CandidateId);

        modelBuilder.Entity<CandidateSkill>()
            .HasOne(es => es.Skill)
            .WithMany()
            .HasForeignKey(es => es.SkillId);

        modelBuilder.Entity<Candidate>()
            .HasMany(e => e.CandidateCertificates)
            .WithOne(ec => ec.Candidate)
            .HasForeignKey(ec => ec.CandidateId);

        modelBuilder.Entity<CandidateCertificate>()
            .HasOne(ec => ec.Certificate)
            .WithMany()
            .HasForeignKey(ec => ec.CertificateId);

        modelBuilder.Entity<Candidate>()
            .HasMany(e => e.CandidateLanguageSkills)
            .WithOne(els => els.Candidate)
            .HasForeignKey(els => els.CandidateId);

        modelBuilder.Entity<CandidateLanguageSkill>()
            .HasOne(els => els.LanguageSkill)
            .WithMany()
            .HasForeignKey(els => els.LanguageSkillId);

        modelBuilder.Entity<Candidate>()
            .HasMany(e => e.CandidatePublications)
            .WithOne(ep => ep.Candidate)
            .HasForeignKey(ep => ep.CandidateId);

        modelBuilder.Entity<CandidatePublication>()
            .HasOne(ep => ep.Publication)
            .WithMany()
            .HasForeignKey(ep => ep.PublicationId);
    }
}