using Diploma.Application.Contracts.Services;
using Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        
        return services;
    }
}