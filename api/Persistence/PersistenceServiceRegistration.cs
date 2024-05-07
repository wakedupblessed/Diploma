using Diploma.Application.Contracts.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        services.AddScoped<ICandidateRepository, CandidateRepository>();

        services.AddScoped<IVacancyRepository, VacancyRepository>();
        
        return services;
    }
}