namespace Diploma.Domain.Common;

public class CandidateRelationshipBase : BaseEntity
{
    public required string CandidateId { get; set; }
    public Candidate Candidate { get; set; }
}