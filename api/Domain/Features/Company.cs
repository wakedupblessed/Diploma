using Diploma.Domain.Common;

namespace Diploma.Domain.Features;

public class Company : BaseEntity
{
    public string Name { get; set; }
    public List<Certificate> Certificates { get; set; } = new();
    
    public Company()
    {
        
    }
}