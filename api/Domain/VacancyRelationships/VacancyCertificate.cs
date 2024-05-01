using Diploma.Domain.Common;
using Diploma.Domain.Features;

namespace Diploma.Domain.VacancyRelationships;

public class VacancyCertificate : VacancyRelationshipBase
{
    public required string CertificateId { get; set; }
    public required Certificate Certificate { get; set; }

    public VacancyCertificate()
    {
        
    }
}