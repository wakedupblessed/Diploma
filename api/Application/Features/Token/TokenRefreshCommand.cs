using Diploma.Application.Shared;
using MediatR;

namespace Diploma.Application.Features.Token;

public record TokenRefreshCommand(string Email, string AccessToken, string RefreshToken) : IRequest<Result<TokenDto>>;
