using Diploma.Domain.Common;

namespace Diploma.Domain.Features;

public class Certificate : BaseEntity
{
    public string Name { get; set; }
        
    public string CompanyId { get; set; }
    public Company Company { get; set; }

    public Certificate()
    {
        
    }
}