using AutoMapper;
using Diploma.Application.Contracts.DTOs.Svm;
using Diploma.Application.Contracts.Persistence;
using Diploma.Application.Contracts.Services;
using Diploma.Application.Shared;
using FluentValidation;
using MediatR;

namespace Diploma.Application.Features.Feedback;

public class FeedbackCreateCommandHandler : IRequestHandler<FeedbackCreateCommand, Result<List<SelectionResult>?>>
{
    private readonly ISvmPredictionService _predictionService;
    private readonly IValidator<FeedbackCreateCommand> _validator;
    private readonly IVacancyRepository _vacancyRepository;
    private readonly ICandidateRepository _candidateRepository;
    private readonly IMapper _mapper;
    
    public FeedbackCreateCommandHandler(ISvmPredictionService predictionService, IValidator<FeedbackCreateCommand> validator,
        IMapper mapper, IVacancyRepository vacancyRepository,
        ICandidateRepository candidateRepository)
    {
        _predictionService = predictionService;
        _validator = validator;
        _mapper = mapper;
        _vacancyRepository = vacancyRepository;
        _candidateRepository = candidateRepository;
    }

    public async Task<Result<List<SelectionResult>?>> Handle(FeedbackCreateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            return Result<List<SelectionResult>?>.Failure((validationResult.Errors.First().CustomState as Error)!);
        }

        var vacancy = await _vacancyRepository.GetByIdAsync(request.VacancyId);

        var candidatesId = vacancy.CandidateVacancies.Select(c => c.CandidateId);

        var candidates = await _candidateRepository.FindAsync(c => candidatesId.Contains(c.Id));

        var vacancyDto = _mapper.Map<VacancySvmDto>(vacancy);

        var candidatesDto = _mapper.Map<List<VacancySvmDto>>(candidates);
        
        var mostSuitableCandidates = await _predictionService.GetTheMostSuitableCandidates(candidatesDto, vacancyDto);

        foreach (var candidate in mostSuitableCandidates)
        {
            var candidateInfo = candidates.Find(c => c.Id == candidate.Candidate);

            candidate.Name = candidateInfo.FullName;
            candidate.YearsOfExperience = candidateInfo.Experience;
        }
        
        return mostSuitableCandidates;
    }
}