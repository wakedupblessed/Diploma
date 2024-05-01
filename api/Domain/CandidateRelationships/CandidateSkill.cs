using Diploma.Domain.Common;
using Diploma.Domain.Features;

namespace Diploma.Domain.CandidateRelationships;

public class CandidateSkill : CandidateRelationshipBase
{
    public required string SkillId { get; set; }
    public required Skill Skill { get; set; }
    
    public int Level { get; set; }

    public CandidateSkill()
    {
        
    }
}