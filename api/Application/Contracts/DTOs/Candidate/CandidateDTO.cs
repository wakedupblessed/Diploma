using Diploma.Application.Contracts.DTOs.Vacancy;

namespace Diploma.Application.Contracts.DTOs.Candidate;

public class CandidateDTO
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string Description { get; set; }
    public double SalaryExpectation { get; set; }
    public double Experience { get; set; }
    public LocationDTO Location { get; set; }
    public List<SkillDTO> CandidateSkills { get; set; }
    public List<CertificateDTO> CandidateCertificates { get; set; }
    public List<LanguageSkillDTO> CandidateLanguageSkills { get; set; }
    public List<PublicationDTO> CandidatePublications { get; set; }
    public EducationDTO Education { get; set; }
}