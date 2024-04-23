using FeedbackAnalyzer.Domain.Common;

namespace FeedbackAnalyzer.Domain;

public class User : BaseEntity
{
    public required string IdentityId { get; set; }
    public required string FullName { get; set; }
    public string? Rating { get; set; }
}