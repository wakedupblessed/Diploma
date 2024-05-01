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
            .FirstOrDefaultAsync(p => p.Id == id);

    public override Task<List<Candidate>> FindAsync(Expression<Func<Candidate, bool>> predicate)
        => DbSet
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();
}