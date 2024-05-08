using AutoMapper;
using Diploma.Application.Contracts.DTOs.Candidate;
using Diploma.Domain;

namespace Diploma.Application.MappingProfiles;

public class CandidateProfile : Profile
{
    public CandidateProfile()
    {
        CreateMap<Candidate, CandidateDTO>();
    }
}