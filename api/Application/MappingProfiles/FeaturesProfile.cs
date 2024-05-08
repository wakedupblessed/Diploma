using AutoMapper;
using Diploma.Application.Contracts.DTOs.Vacancy;
using Diploma.Domain.CandidateRelationships;
using Diploma.Domain.Features;
using Diploma.Domain.VacancyRelationships;

namespace Diploma.Application.MappingProfiles;

public class FeaturesProfile : Profile
{
    public FeaturesProfile()
    {
        CreateMap<Location, LocationDTO>();

        CreateMap<VacancyCertificate, CertificateDTO>()
            .ForMember(dest => dest.Name, src => src.MapFrom(c => c.Certificate.Name))
            .ForMember(dest => dest.CompanyName, src => src.MapFrom(c => c.Certificate.Company.Name));

        CreateMap<VacancySkill, SkillDTO>()
            .ForMember(dest => dest.Name, src => src.MapFrom(c => c.Skill.Name))
            .ForMember(dest => dest.Level, src => src.MapFrom(c => c.Level));

        CreateMap<VacancyLanguageSkill, LanguageSkillDTO>()
            .ForMember(dest => dest.Name, src => src.MapFrom(c => c.LanguageSkill.Name))
            .ForMember(dest => dest.Level, src => src.MapFrom(c => c.Level));

        CreateMap<VacancyPublication, PublicationDTO>()
            .ForMember(dest => dest.Doi, src => src.MapFrom(c => c.Publication.Doi))
            .ForMember(dest => dest.Title, src => src.MapFrom(c => c.Publication.Title))
            .ForMember(dest => dest.JournalName, src => src.MapFrom(c => c.Publication.JournalName))
            .ForMember(dest => dest.YearOfPublication, src => src.MapFrom(c => c.Publication.YearOfPublication));
        
        CreateMap<Educations, EducationDTO>()
            .ForMember(dest => dest.Name, src => src.MapFrom(c => c.SpecificFieldOfStudy))
            .ForMember(dest => dest.Level, src => src.MapFrom(c => c.RequiredEducationLevel));
        
        CreateMap<CandidateCertificate, CertificateDTO>()
            .ForMember(dest => dest.Name, src => src.MapFrom(c => c.Certificate.Name))
            .ForMember(dest => dest.CompanyName, src => src.MapFrom(c => c.Certificate.Company.Name));

        CreateMap<CandidateSkill, SkillDTO>()
            .ForMember(dest => dest.Name, src => src.MapFrom(c => c.Skill.Name))
            .ForMember(dest => dest.Level, src => src.MapFrom(c => c.Level));

        CreateMap<CandidateLanguageSkill, LanguageSkillDTO>()
            .ForMember(dest => dest.Name, src => src.MapFrom(c => c.LanguageSkill.Name))
            .ForMember(dest => dest.Level, src => src.MapFrom(c => c.Level));

        CreateMap<CandidatePublication, PublicationDTO>()
            .ForMember(dest => dest.Doi, src => src.MapFrom(c => c.Publication.Doi))
            .ForMember(dest => dest.Title, src => src.MapFrom(c => c.Publication.Title))
            .ForMember(dest => dest.JournalName, src => src.MapFrom(c => c.Publication.JournalName))
            .ForMember(dest => dest.YearOfPublication, src => src.MapFrom(c => c.Publication.YearOfPublication));
    }
}