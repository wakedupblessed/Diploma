using Diploma.Domain.Common;
using Diploma.Domain.Features;

namespace Diploma.Domain.CandidateRelationships;

public class CandidateCertificate : CandidateRelationshipBase
{
    public required string CertificateId { get; set; }
    public required Certificate Certificate { get; set; }

    public CandidateCertificate()
    {
    }
}