using Diploma.Application.Features.Token;
using Diploma.Application.Shared;
using Identity.Models;

namespace Diploma.Application.Contracts.Services;

public interface IJwtTokenService
{
    Task<Result<TokenDto>> GenerateTokenPairAsync(ApplicationUser user);
    Task<Result<TokenDto>> RefreshTokenAsync(RefreshTokenDto tokenModel);
}