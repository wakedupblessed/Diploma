using Diploma.Domain.Common;
using Diploma.Domain.CandidateRelationships;
using Diploma.Domain.Features;

namespace Diploma.Domain;

public class Candidate : BaseEntity
{
    public required string IdentityId { get; set; }
    public required string FullName { get; set; }
    public string? Description { get; set; }
    public double SalaryExpectation { get; set; }
    public double Experience { get; set; }
    public required string LocationId { get; set; }
    public required Location Location { get; set; }
    public List<CandidateSkill> CandidateSkills { get; set; } = new();
    public List<CandidateCertificate> CandidateCertificates { get; set; } = new();
    public List<CandidateLanguageSkill> CandidateLanguageSkills { get; set; } = new();
    public List<CandidatePublication> CandidatePublications { get; set; } = new();
    public Educations Education { get; set; }
    public List<CandidateVacancy> CandidateVacancies { get; set; } = new();

    public Candidate()
    {
        
    }
}