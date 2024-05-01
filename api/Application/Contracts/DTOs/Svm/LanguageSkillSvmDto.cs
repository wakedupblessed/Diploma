using Diploma.Domain.Features;

namespace Diploma.Application.Contracts.DTOs.Svm;

public class LanguageSkillSvmDto
{
    public string Language { get; set; }
    public LanguageLevel Proficiency { get; set; }
}