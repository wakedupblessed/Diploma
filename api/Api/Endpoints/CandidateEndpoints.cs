using Diploma.Api.Extensions;
using Diploma.Application.Features.Candidate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Api.Endpoints;

public static class CandidateEndpoints
{
    public static void AddCandidateEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/candidates/{id}", async ([FromRoute] string id, [FromServices] ISender sender) =>
        {
            var result = await sender.Send(new GetCandidateByIdQuery(id));

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });
    }
}