using Diploma.Domain.Features;

namespace Diploma.Application.Contracts.DTOs.Svm;

public class SkillSvmDto
{
    public string SkillName { get; set; }
    public int Level { get; set; }
}

public class EducationSvmDTO
{
    public string Name { get; set; }
    public EducationLevel Level { get; set; }
}