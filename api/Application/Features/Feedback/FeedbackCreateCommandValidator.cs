using Diploma.Application.Contracts.Persistence;
using Diploma.Application.Shared.EntityErrors;
using FluentValidation;

namespace Diploma.Application.Features.Feedback;

public class FeedbackCreateCommandValidator : AbstractValidator<FeedbackCreateCommand>
{
    private readonly IGenericRepository<Domain.Vacancy> _vacancyRepository;

    public FeedbackCreateCommandValidator(IGenericRepository<Domain.Vacancy> vacancyRepository)
    {
        _vacancyRepository = vacancyRepository;
        
        RuleFor(x => x.VacancyId)
            .MustAsync(VacancyShouldExists)
            .WithState(_ => VacancyErrors.NotFound(_.VacancyId));
    }
    
    private async Task<bool> VacancyShouldExists(string locationId, CancellationToken cancellationToken)
        => await _vacancyRepository.GetByIdAsync(locationId) is not null;
}