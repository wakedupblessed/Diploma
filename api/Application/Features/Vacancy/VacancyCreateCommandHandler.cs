using AutoMapper;
using Diploma.Application.Contracts.Persistence;
using Diploma.Application.Shared;
using FluentValidation;
using MediatR;

namespace Diploma.Application.Features.Vacancy;

public class VacancyCreateCommandHandler : IRequestHandler<VacancyCreateCommand, Result<string>>
{
    private readonly IGenericRepository<Domain.Vacancy> _vacancyRepository;
    private readonly IValidator<VacancyCreateCommand> _validator;
    private readonly IMapper _mapper;

    public VacancyCreateCommandHandler(IGenericRepository<Domain.Vacancy> vacancyRepository, IMapper mapper,
        IValidator<VacancyCreateCommand> validator)
    {
        _vacancyRepository = vacancyRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<string>> Handle(VacancyCreateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            return Result<string>.Failure((validationResult.Errors.First().CustomState as Error)!);
        }

        var vacancy = _mapper.Map<Domain.Vacancy>(request);

        await _vacancyRepository.CreateAsync(vacancy);

        return vacancy.Id;
    }
}