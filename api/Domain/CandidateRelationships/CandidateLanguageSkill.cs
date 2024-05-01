using Diploma.Domain.Common;
using Diploma.Domain.Features;

namespace Diploma.Domain.CandidateRelationships;

public class CandidateLanguageSkill : CandidateRelationshipBase
{
    public required string LanguageSkillId { get; set; }
    public required LanguageSkill LanguageSkill { get; set; }

    public CandidateLanguageSkill()
    {
        
    }
}