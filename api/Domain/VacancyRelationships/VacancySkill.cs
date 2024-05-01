using Diploma.Domain.Common;
using Diploma.Domain.Features;

namespace Diploma.Domain.VacancyRelationships;

public class VacancySkill : VacancyRelationshipBase
{
    public required string SkillId { get; set; }
    public Skill Skill { get; set; }
    
    public int Level { get; set; }

    public VacancySkill()
    {
        
    }
}