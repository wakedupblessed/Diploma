using Diploma.Domain.Common;

namespace Diploma.Domain.Features;

public class Educations : BaseEntity
{
    public string SpecificFieldOfStudy { get; set; }
    public EducationLevel RequiredEducationLevel { get; set; }
}

public enum EducationLevel
{
    BachelorsDegree,
    MastersDegree,
    Doctorate,
    ProfessionalCertification
}
