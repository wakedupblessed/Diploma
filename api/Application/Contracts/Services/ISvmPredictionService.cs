using Diploma.Application.Contracts.DTOs.Svm;

namespace Diploma.Application.Contracts.Services;

public interface ISvmPredictionService
{
    Task<string> GetTheMostSuitableCandidates(List<VacancySvmDto> candidates, VacancySvmDto vacancy);
}