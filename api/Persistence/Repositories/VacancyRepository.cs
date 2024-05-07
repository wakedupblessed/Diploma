using System.Linq.Expressions;
using Diploma.Application.Contracts.Persistence;
using Diploma.Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContext;

namespace Persistence.Repositories;

public class VacancyRepository : GenericRepository<Vacancy>, IVacancyRepository
{
    public VacancyRepository(ApplicationDatabaseContext context)
        : base(context)
    {
    }

    public override async Task<List<Vacancy>> GetAsync()
        => await DbSet
            .AsNoTracking()
            .Include(v => v.Location)
            .Include(v => v.CandidateVacancies)
            .Include(v => v.VacancyCertificates).ThenInclude(s => s.Certificate).ThenInclude(s => s.Company)
            .Include(v => v.VacancyLanguageSkills).ThenInclude(s => s.LanguageSkill)
            .Include(v => v.VacancySkills).ThenInclude(s => s.Skill)
            .Include(v => v.RequiredEducation)
            .ToListAsync();

    public override async Task<Vacancy?> GetByIdAsync(string id)
        => await DbSet
            .AsNoTracking()
            .Include(v => v.Location)
            .Include(v => v.CandidateVacancies)
            .Include(v => v.VacancyCertificates).ThenInclude(s => s.Certificate).ThenInclude(s => s.Company)
            .Include(v => v.VacancyLanguageSkills).ThenInclude(s => s.LanguageSkill)
            .Include(v => v.VacancySkills).ThenInclude(s => s.Skill)
            .Include(v => v.RequiredEducation)

            .FirstOrDefaultAsync(p => p.Id == id);

    public override async Task<List<Vacancy>> FindAsync(Expression<Func<Vacancy, bool>> predicate)
        => await DbSet
            .AsNoTracking()
            .Include(v => v.Location)
            .Include(v => v.CandidateVacancies)
            .Include(v => v.VacancyCertificates).ThenInclude(s => s.Certificate).ThenInclude(s => s.Company)
            .Include(v => v.VacancyLanguageSkills).ThenInclude(s => s.LanguageSkill)
            .Include(v => v.VacancySkills).ThenInclude(s => s.Skill)
            .Include(v => v.RequiredEducation)
            .Where(predicate)
            .ToListAsync();
}