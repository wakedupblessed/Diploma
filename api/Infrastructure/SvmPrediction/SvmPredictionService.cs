using System.Text;
using Diploma.Application.Contracts.DTOs.Svm;
using Diploma.Application.Contracts.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.SvmPrediction;

public class SvmPredictionService : ISvmPredictionService
{
    private readonly SvmPredictionOptions _options;
    private readonly HttpClient _httpClient;

    public SvmPredictionService(IOptions<SvmPredictionOptions> svmSettings, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _options = svmSettings.Value;
    }

    public async Task<List<SelectionResult>?> GetTheMostSuitableCandidates(List<VacancySvmDto> candidates,
        VacancySvmDto vacancy)
    {
        var request = new
        {
            candidates, vacancy
        };

        var jsonRequest = JsonConvert.SerializeObject(request);

        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_options.RequestUrl}/predict", content);

        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<List<SelectionResult>>(jsonResponse);
    }
}