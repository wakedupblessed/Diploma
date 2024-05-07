using Infrastructure.SvmPrediction;
using Microsoft.Extensions.Options;

namespace Diploma.Api.OptionsSetup;

public class SvmPredictionOptionsSetup : IConfigureOptions<SvmPredictionOptions>
{
    private const string SectionName = "SvmSettings";

    private readonly IConfiguration _configuration;
    
    public SvmPredictionOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void Configure(SvmPredictionOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}