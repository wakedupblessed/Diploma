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
    public List<VacancySkillDTO> VacancySkills { get; set; }
    public List<VacancyCertificateDTO> VacancyCertificates { get; set; }
    public List<VacancyLanguageSkillDTO> VacancyLanguageSkills { get; set; }
    public EducationDTO Education { get; set; }
}

public class LocationDTO
{
    public string Name { get; set; } 
}

public class VacancySkillDTO
{
    public string Name { get; set; } 
    public int Level { get; set; }
}

public class VacancyCertificateDTO
{
    public string Name { get; set; }
    public string CompanyName { get; set; } 
}

public class VacancyLanguageSkillDTO
{
    public string Name { get; set; }
    public LanguageLevel Level { get; set; }
}

public class VacancyPublicationDTO
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
