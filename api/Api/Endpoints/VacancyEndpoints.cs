using Diploma.Api.Extensions;
using Diploma.Application.Features.Vacancy.GetVacancies;
using Diploma.Application.Features.Vacancy.GetVacancyById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Api.Endpoints;

public static class VacancyEndpoints
{
    public static void AddVacancyEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/vacancies", async ([FromServices] ISender sender) =>
        {
            var result = await sender.Send(new GetVacanciesQuery());
            
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });
        
        app.MapGet("/vacancies/{id}", async ([FromRoute] string id, [FromServices] ISender sender) =>
        {
            var result = await sender.Send(new GetVacancyByIdQuery(id));

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });
    }
}