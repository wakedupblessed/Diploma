using AutoMapper;
using Diploma.Application.Contracts.DTOs.Svm;
using Diploma.Domain;

namespace Diploma.Application.MappingProfiles;

public class SvmProfile : Profile
{
    public SvmProfile()
    {
        CreateMap<Vacancy, VacancySvmDto>()
            .ForMember(dest => dest.City,
                opt => opt.MapFrom(src => src.Location.Name))
            .ForMember(dest => dest.Skills,
                opt => opt.MapFrom(src =>
                    src.VacancySkills.Select(vs => new SkillSvmDto { SkillName = vs.Skill.Name, Level = vs.Level })))
            .ForMember(dest => dest.LanguageSkills,
                opt => opt.MapFrom(src => src.VacancyLanguageSkills.Select(vls => new LanguageSkillSvmDto
                    { Language = vls.LanguageSkill.Name, Proficiency = vls.LanguageSkill.Level })))
            .ForMember(dest => dest.Publications, opt => opt.MapFrom(src => src.VacancyPublications.Count))
            .ForMember(dest => dest.Certificates,
                opt => opt.MapFrom(src => src.VacancyCertificates.Select(vc => vc.Certificate.Name)));
    }
}