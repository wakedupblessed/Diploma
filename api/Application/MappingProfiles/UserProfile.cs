using AutoMapper;
using Diploma.Application.Contracts.DTOs;
using Diploma.Application.Features.Identity.Register;
using Diploma.Domain;
using Identity.Models;

namespace Diploma.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<ApplicationUser, Candidate>()
            .ForMember(dest => dest.IdentityId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid().ToString()));

        CreateMap<RegisterCommand, ApplicationUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.FullName.Replace(" ", "")));

        CreateMap<Candidate, UserDto>();
    }
}