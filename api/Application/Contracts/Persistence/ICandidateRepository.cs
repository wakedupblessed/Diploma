using Diploma.Domain;
using Diploma.Domain.VacancyRelationships;

namespace Diploma.Application.Contracts.Persistence;

public interface ICandidateRepository : IGenericRepository<Candidate>
{
}

public interface IVacancyRepository : IGenericRepository<Vacancy>
{
    
}