using Diploma.Application.Contracts.DTOs;
using Diploma.Application.Contracts.Persistence;
using Diploma.Application.Shared.EntityErrors;
using Diploma.Domain.Features;
using FluentValidation;

namespace Diploma.Application.Features.Vacancy;

public class VacancyCreateCommandValidator : AbstractValidator<VacancyCreateCommand>
{
    private readonly IGenericRepository<Skill> _skillRepository;
    private readonly IGenericRepository<Location> _locationRepository;

    public VacancyCreateCommandValidator(IGenericRepository<Skill> skillRepository,
        IGenericRepository<Location> locationRepository)
    {
        _skillRepository = skillRepository;
        _locationRepository = locationRepository;

        RuleFor(p => p.JobTitle)
            .NotEmpty()
            .WithState(_ => VacancyErrors.MissingInformation("job title"))
            .MaximumLength(100)
            .WithState(_ => VacancyErrors.InvalidInformation("job title"));

        RuleFor(p => p.Description)
            .NotEmpty()
            .WithState(_ => VacancyErrors.MissingInformation("job description"))
            .MaximumLength(100)
            .WithState(_ => VacancyErrors.InvalidInformation("job description"));

        RuleFor(p => p.SalaryExpectation)
            .GreaterThanOrEqualTo(0)
            .WithState(_ => VacancyErrors.InvalidSalary());

        RuleFor(p => p.ExperienceYears)
            .GreaterThanOrEqualTo(0)
            .WithState(_ => VacancyErrors.InvalidExperienceYears());
        
        RuleFor(x => x.LocationId)
            .MustAsync(LocationShouldExists)
            .WithState(_ => VacancyErrors.InvalidLocation(_.LocationId));
        
        RuleFor(x => x.VacancySkills)
            .MustAsync(SkillsShouldExists)
            .WithState(_ => VacancyErrors.InvalidSkillSet());
    }

    private async Task<bool> LocationShouldExists(string locationId, CancellationToken cancellationToken)
        => await _locationRepository.GetByIdAsync(locationId) is not null;

    private async Task<bool> SkillsShouldExists(List<SkillDto>? dtos, CancellationToken cancellationToken)
    {
        var skillIds = dtos.Select(dto => dto.SkillId).Distinct().ToList();

        var foundSkills = await _skillRepository
            .FindAsync(skill => skillIds.Contains(skill.Id));

        var foundSkillsIds = foundSkills
            .Select(skill => skill.Id)
            .Distinct()
            .ToList();

        return skillIds.Count == foundSkillsIds.Count;
    }
}