using AutoMapper;
using Diploma.Application.Contracts.DTOs.Vacancy;
using Diploma.Application.Contracts.Persistence;
using Diploma.Application.Shared;
using Diploma.Application.Shared.EntityErrors;
using MediatR;

namespace Diploma.Application.Features.Vacancy.GetVacancyById;

public record GetVacancyByIdQuery(string Id) : IRequest<Result<VacancyDTO>>;

public class GetVacancyByIdQueryHandler : IRequestHandler<GetVacancyByIdQuery, Result<VacancyDTO>>
{
    private readonly IVacancyRepository _vacancyRepository;
    private readonly IMapper _mapper;

    public GetVacancyByIdQueryHandler(IMapper mapper, IVacancyRepository vacancyRepository)
    {
        _vacancyRepository = vacancyRepository;
        _mapper = mapper;
    }

    public async Task<Result<VacancyDTO>> Handle(GetVacancyByIdQuery request, CancellationToken cancellationToken)
    {
        var vacancy = await _vacancyRepository.GetByIdAsync(request.Id);

        return vacancy is null
            ? Result<VacancyDTO>.Failure(VacancyErrors.NotFound(request.Id))
            : _mapper.Map<VacancyDTO>(vacancy);
    }
}