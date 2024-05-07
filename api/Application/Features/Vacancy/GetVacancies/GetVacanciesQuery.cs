using AutoMapper;
using Diploma.Application.Contracts.DTOs.Vacancy;
using Diploma.Application.Contracts.Persistence;
using Diploma.Application.Shared;
using MediatR;

namespace Diploma.Application.Features.Vacancy.GetVacancies;

public record GetVacanciesQuery : IRequest<Result<List<VacancyDTO>>>;

public class GetArticlesQueryHandler : IRequestHandler<GetVacanciesQuery, Result<List<VacancyDTO>>>
{
    private readonly IVacancyRepository _vacancyRepository;
    private readonly IMapper _mapper;

    public GetArticlesQueryHandler(IMapper mapper, IVacancyRepository vacancyRepository)
    {
        _vacancyRepository = vacancyRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<VacancyDTO>>> Handle(GetVacanciesQuery request, CancellationToken cancellationToken)
    {
        var vacancies = await _vacancyRepository.GetAsync();

        return _mapper.Map<List<VacancyDTO>>(vacancies);
    }
}