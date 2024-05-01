using Diploma.Application.Contracts.DTOs;
using Diploma.Application.Shared;
using MediatR;

namespace Diploma.Application.Features.Vacancy;

public class VacancyCreateCommand : IRequest<Result<string>>
{
    public required string Id { get; set; }
    public required string JobTitle { get; set; }
    public required string Description { get; set; }
    public double SalaryExpectation { get; set; }
    public int ExperienceYears { get; set; }
    public string LocationId { get; set; }

    public List<SkillDto>? VacancySkills { get; set; }
    // public List<string>? Certificates { get; set; }
    // public List<string>? LanguageSkills { get; set; }
    // public List<string>? Publications { get; set; }
}