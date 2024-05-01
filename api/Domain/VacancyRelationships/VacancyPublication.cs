using Diploma.Domain.Common;
using Diploma.Domain.Features;

namespace Diploma.Domain.VacancyRelationships;

public class VacancyPublication : VacancyRelationshipBase
{
    public required string PublicationId { get; set; }
    public required Publication Publication { get; set; }

    public VacancyPublication()
    {
        
    }
}