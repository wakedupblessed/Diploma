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
                    { Language = vls.LanguageSkill.Name, Proficiency = vls.Level })))
            .ForMember(dest => dest.Education, opt => opt.MapFrom(src => new EducationSvmDTO
            {
                Name = src.RequiredEducation.SpecificFieldOfStudy,
                Level = src.RequiredEducation.RequiredEducationLevel
            }))
            .ForMember(dest => dest.Certificates,
                opt => opt.MapFrom(src => src.VacancyCertificates.Select(vc => vc.Certificate.Name)));

        CreateMap<Candidate, VacancySvmDto>()
            .ForMember(dest => dest.City,
                opt => opt.MapFrom(src => src.Location.Name))
            .ForMember(dest => dest.Skills,
                opt => opt.MapFrom(src =>
                    src.CandidateSkills.Select(vs => new SkillSvmDto { SkillName = vs.Skill.Name, Level = vs.Level })))
            .ForMember(dest => dest.LanguageSkills,
                opt => opt.MapFrom(src => src.CandidateLanguageSkills.Select(vls => new LanguageSkillSvmDto
                    { Language = vls.LanguageSkill.Name, Proficiency = vls.Level })))
            .ForMember(dest => dest.Publications, opt => opt.MapFrom(src => src.CandidatePublications.Count))
            .ForMember(dest => dest.Certificates,
                opt => opt.MapFrom(src => src.CandidateCertificates.Select(vc => vc.Certificate.Name)))
            .ForMember(dest => dest.Education, opt => opt.MapFrom(src => new EducationSvmDTO
            {
                Name = src.Education.SpecificFieldOfStudy,
                Level = src.Education.RequiredEducationLevel
            }));
    }
}