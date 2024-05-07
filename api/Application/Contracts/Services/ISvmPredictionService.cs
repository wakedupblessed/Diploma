using Diploma.Application.Contracts.DTOs.Svm;

namespace Diploma.Application.Contracts.Services;

public interface ISvmPredictionService
{
    Task<List<SelectionResult>?> GetTheMostSuitableCandidates(List<VacancySvmDto> candidates, VacancySvmDto vacancy);
}