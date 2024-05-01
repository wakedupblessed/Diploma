using Diploma.Application.Features.Identity.Login;
using Diploma.Application.Features.Identity.Register;
using Diploma.Application.Features.Token;
using Diploma.Api.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Diploma.Api.Endpoints;

public static class AuthenticationEndpoints
{
    public static void AddAuthenticationEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/register", async (RegisterCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.IsSuccess ? Results.Ok() : result.ToProblemDetails();
        });
        
        app.MapPost("/login", async (LoginCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });
        
        app.MapPost("/refresh-token", [Authorize]
            async (TokenRefreshCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });
    }
}