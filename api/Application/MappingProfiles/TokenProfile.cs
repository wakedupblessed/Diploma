using AutoMapper;
using Diploma.Application.Features.Token;

namespace Diploma.Application.MappingProfiles;

public class TokenProfile : Profile
{
    public TokenProfile()
    {
        CreateMap<TokenRefreshCommand, RefreshTokenDto>();
    }
}