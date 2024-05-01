namespace Diploma.Application.Contracts.DTOs.Svm;

public class VacancySvmDto
{
    public string Id { get; set; }
    public string JobTitle { get; set; }
    public string Description { get; set; }
    public int SalaryExpectation { get; set; }
    public string City { get; set; }  
    public int ExperienceYears { get; set; }
    public List<SkillSvmDto> Skills { get; set; } = new();
    public List<LanguageSkillSvmDto> LanguageSkills { get; set; } = new();
    public int Publications { get; set; }
    public List<string> Certificates { get; set; } = new();
}