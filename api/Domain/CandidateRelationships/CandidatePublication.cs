using Diploma.Domain.Common;
using Diploma.Domain.Features;

namespace Diploma.Domain.CandidateRelationships;

public class CandidatePublication : CandidateRelationshipBase
{
    public required string PublicationId { get; set; }
    public required Publication Publication { get; set; }

    public CandidatePublication()
    {
        
    }
}