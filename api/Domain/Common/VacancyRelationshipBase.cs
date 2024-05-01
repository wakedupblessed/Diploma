namespace Diploma.Domain.Common;

public class VacancyRelationshipBase : BaseEntity
{
    public required string VacancyId { get; set; }
    public Vacancy Vacancy { get; set; }
}