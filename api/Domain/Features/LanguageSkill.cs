using Diploma.Domain.Common;

namespace Diploma.Domain.Features;

public class LanguageSkill : BaseEntity
{
    public required string Name { get; set; }
   

    public LanguageSkill()
    {
        
    }
}

public enum LanguageLevel
{
    A1,
    A2,
    B1,
    B2,
    C1,
    C2
}