using Diploma.Application.Shared;
using MediatR;

namespace Diploma.Application.Features.Identity.Register;

public record RegisterCommand(string Email, string FullName, string Password) : IRequest<Result<Unit>>;