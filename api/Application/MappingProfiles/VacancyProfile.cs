using AutoMapper;
using Diploma.Application.Contracts.DTOs;
using Diploma.Application.Features.Vacancy;
using Diploma.Domain;
using Diploma.Domain.VacancyRelationships;

namespace Diploma.Application.MappingProfiles;

public class VacancyProfile : Profile
{
    public VacancyProfile()
    {
        CreateMap<VacancyCreateCommand, Vacancy>()
            .ForMember(dest => dest.VacancySkills, opt => opt.MapFrom(src =>
                (src.VacancySkills ?? new List<SkillDto>()).Select(skill =>
                    new VacancySkill
                    {
                        Id = Guid.NewGuid().ToString(),
                        SkillId = skill.SkillId,
                        Level = skill.Level,
                        VacancyId = src.Id,
                    })));
    }
}