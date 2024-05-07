using Diploma.Domain.Common;
using Diploma.Domain.Features;
using Diploma.Domain.VacancyRelationships;

namespace Diploma.Domain;

public class Vacancy : BaseEntity
{
    public required string JobTitle { get; set; }
    
    public required string Description { get; set; }
    
    public int SalaryExpectation { get; set; }
    
    public int ExperienceYears { get; set; }
    public string LocationId { get; set; }
    public Location Location { get; set; }
    public List<VacancySkill> VacancySkills { get; set; } = new();
    public List<VacancyCertificate> VacancyCertificates { get; set; } = new();
    public List<VacancyLanguageSkill> VacancyLanguageSkills { get; set; } = new();
    public Educations RequiredEducation { get; set; }
    public List<CandidateVacancy> CandidateVacancies { get; set; } = new();
    
    public Vacancy()
    {
    }
}