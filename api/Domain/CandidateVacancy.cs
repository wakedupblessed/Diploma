using Diploma.Domain.Common;

namespace Diploma.Domain;

public class CandidateVacancy : BaseEntity
{
    public string CandidateId { get; set; }
    public required Candidate Candidate { get; set; }

    public string VacancyId { get; set; }
    public required Vacancy Vacancy { get; set; }

    public CandidateVacancy()
    {
        
    }
}