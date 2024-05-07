using System.Linq.Expressions;
using Diploma.Application.Contracts.Persistence;
using Diploma.Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContext;

namespace Persistence.Repositories;

public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
{
    public CandidateRepository(ApplicationDatabaseContext context)
        : base(context)
    {
    }

    public override async Task<Candidate?> GetByIdAsync(string id)
        => await DbSet
            .AsNoTracking()
            .Include(v => v.Location)
            .Include(v => v.CandidateCertificates).ThenInclude(s => s.Certificate)
            .Include(v => v.CandidatePublications).ThenInclude(s => s.Publication)
            .Include(v => v.CandidateLanguageSkills).ThenInclude(s => s.LanguageSkill)
            .Include(v => v.CandidateSkills).ThenInclude(s => s.Skill)
            .Include(v => v.Education)
            .FirstOrDefaultAsync(p => p.Id == id);

    public override Task<List<Candidate>> FindAsync(Expression<Func<Candidate, bool>> predicate)
        => DbSet
            .AsNoTracking()
            .Include(v => v.Location)
            .Include(v => v.CandidateCertificates).ThenInclude(s => s.Certificate)
            .Include(v => v.CandidatePublications).ThenInclude(s => s.Publication)
            .Include(v => v.CandidateLanguageSkills).ThenInclude(s => s.LanguageSkill)
            .Include(v => v.CandidateSkills).ThenInclude(s => s.Skill)
            .Include(v => v.Education)
            .Where(predicate)
            .ToListAsync();
}