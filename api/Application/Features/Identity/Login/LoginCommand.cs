using Diploma.Application.Features.Token;
using Diploma.Application.Shared;
using MediatR;

namespace Diploma.Application.Features.Identity.Login;

public record LoginCommand(string Email, string Password) : IRequest<Result<TokenDto>>;