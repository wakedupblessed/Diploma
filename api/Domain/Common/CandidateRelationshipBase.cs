namespace Diploma.Domain.Common;

public class CandidateRelationshipBase : BaseEntity
{
    public required string CandidateId { get; set; }
    public required Candidate Candidate { get; set; }
}