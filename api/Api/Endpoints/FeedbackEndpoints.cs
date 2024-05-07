using Diploma.Api.Extensions;
using Diploma.Application.Features.Feedback;
using MediatR;

namespace Diploma.Api.Endpoints;

public static class FeedbackEndpoints
{
    public static void AddFeedbackEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/get-candidates", async (FeedbackCreateCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });
    }
}