namespace Diploma.Application.Contracts.DTOs;

public class UserDto
{
    public string Id { get; set; } = null!;
    public string IdentityId { get; set; } = null!;
    public string FullName { get; set; } = null!;
}

public class SkillDto
{
    public string SkillId { get; set; }
    public int Level { get; set; }
}
