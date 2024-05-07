using Diploma.Application.Contracts.Services;
using Infrastructure.Authentication;
using Infrastructure.SvmPrediction;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenService, JwtTokenService>();

        services.AddScoped<ISvmPredictionService, SvmPredictionService>();
        
  

        return services;
    }
}