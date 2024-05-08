using Diploma.Domain.Features;

namespace Diploma.Application.Contracts.DTOs.Vacancy;

public class VacancyDTO
{
    public string Id { get; set; }
    public string JobTitle { get; set; }
    public string Description { get; set; }
    public double SalaryExpectation { get; set; }
    public int ExperienceYears { get; set; }
    public LocationDTO Location { get; set; }
    public List<SkillDTO> VacancySkills { get; set; }
    public List<CertificateDTO> VacancyCertificates { get; set; }
    public List<LanguageSkillDTO> VacancyLanguageSkills { get; set; }
    public EducationDTO Education { get; set; }
}

public class LocationDTO
{
    public string Name { get; set; } 
}

public class SkillDTO
{
    public string Name { get; set; } 
    public int Level { get; set; }
}

public class CertificateDTO
{
    public string Name { get; set; }
    public string CompanyName { get; set; } 
}

public class LanguageSkillDTO
{
    public string Name { get; set; }
    public LanguageLevel Level { get; set; }
}

public class PublicationDTO
{
    public string Title { get; set; }
    public string JournalName { get; set; }
    public string Doi { get; set; }
    public int YearOfPublication { get; set; } 
}

public class EducationDTO
{
    public string Name { get; set; }
    public EducationLevel Level { get; set; }
}
