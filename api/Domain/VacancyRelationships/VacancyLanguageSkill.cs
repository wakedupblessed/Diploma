using Diploma.Domain.Common;
using Diploma.Domain.Features;

namespace Diploma.Domain.VacancyRelationships;

public class VacancyLanguageSkill : VacancyRelationshipBase
{
    public required string LanguageSkillId { get; set; }
    public required LanguageSkill LanguageSkill { get; set; }
    
    public LanguageLevel Level { get; set; }
    
    public VacancyLanguageSkill()
    {
        
    }
}