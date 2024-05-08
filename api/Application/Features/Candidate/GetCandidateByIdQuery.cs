using AutoMapper;
using Diploma.Application.Contracts.DTOs.Candidate;
using Diploma.Application.Contracts.Persistence;
using Diploma.Application.Shared;
using Diploma.Application.Shared.EntityErrors;
using MediatR;

namespace Diploma.Application.Features.Candidate;

public record GetCandidateByIdQuery(string Id) : IRequest<Result<CandidateDTO>>;

public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, Result<CandidateDTO>>
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IMapper _mapper;

    public GetCandidateByIdQueryHandler(IMapper mapper, ICandidateRepository candidateRepository)
    {
        _candidateRepository = candidateRepository;
        _mapper = mapper;
    }

    public async Task<Result<CandidateDTO>> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
    {
        var candidate = await _candidateRepository.GetByIdAsync(request.Id);

        return candidate is null
            ? Result<CandidateDTO>.Failure(CandidateErrors.NotFound(request.Id))
            : _mapper.Map<CandidateDTO>(candidate);
    }
}