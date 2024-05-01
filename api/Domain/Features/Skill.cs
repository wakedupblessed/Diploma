using Diploma.Domain.Common;

namespace Diploma.Domain.Features;

public class Skill : BaseEntity
{
    public required string Name { get; set; }

    public Skill()
    {
        
    }
}

