using Diploma.Domain;
using Diploma.Domain.CandidateRelationships;
using Diploma.Domain.Features;
using Diploma.Domain.VacancyRelationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DbContext;

namespace Persistence;

public static class ApplicationDatabaseInitializer
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var applicationContext = serviceProvider.GetRequiredService<ApplicationDatabaseContext>();

        if ((await applicationContext.Database.GetPendingMigrationsAsync()).Any())
        {
            await applicationContext.Database.MigrateAsync();
        }

        await SeedTestUser(applicationContext);
    }

    private static async Task SeedTestUser(ApplicationDatabaseContext applicationContext)
    {
        // await applicationContext.Locations.AddRangeAsync(Data.Locations);
        //
        // await applicationContext.Skills.AddRangeAsync(Data.Skills);
        //
        // await applicationContext.LanguageSkills.AddRangeAsync(Data.LanguageSkills);
        //
        // await applicationContext.Companies.AddRangeAsync(Data.Companies);
        //
        // await applicationContext.Certificates.AddRangeAsync(Data.Certificates);
        //
        // await applicationContext.Publications.AddRangeAsync(Data.Publications);

        // await CreateVacancy(applicationContext);

        // await CreateIdealCandidates(applicationContext);
        //
        // await CreateDefaultCandidates(applicationContext);
        //
        // await CreateUnsuitableCandidates(applicationContext);

        // await ApplyCandidatesToVacancy(applicationContext);

        // await UpdateJordanTaylor(applicationContext);
        //
        // await applicationContext.SaveChangesAsync();
    }

    private static async Task UpdateJordanTaylor(ApplicationDatabaseContext applicationContext)
    {
        var candidate = applicationContext.Candidates.FirstOrDefault(v => v.FullName == "Jordan Taylor");

        var eduId = Guid.NewGuid().ToString();

        var education = new Educations
        {
            Id = eduId,
            RequiredEducationLevel = EducationLevel.MastersDegree,
            SpecificFieldOfStudy = "Energy Systems"
        };

        candidate.Education = education;
    }

    private static async Task ApplyCandidatesToVacancy(ApplicationDatabaseContext applicationContext)
    {
        var vacancy = applicationContext.Vacancies.FirstOrDefault(v => v.Id == "21406210-a805-4d2c-946a-1f1ba7657836");

        var candidates = applicationContext.Candidates.ToList();

        vacancy.CandidateVacancies = new List<CandidateVacancy>();

        foreach (var VARIABLE in candidates)
        {
            vacancy.CandidateVacancies.Add(new CandidateVacancy()
            {
                Id = Guid.NewGuid().ToString(),
                Candidate = VARIABLE,
                CandidateId = VARIABLE.Id,
                Vacancy = vacancy,
                VacancyId = vacancy.Id
            });
        }
        
        await applicationContext.SaveChangesAsync();
    }

    public static async Task CreateVacancy(ApplicationDatabaseContext context)
    {
        // Assuming the locations are already populated in the database and fetched as needed
        var kyivLocation = context.Locations.FirstOrDefault(l => l.Name == "Kyiv");

        var id = Guid.NewGuid().ToString();

        var vacancy = new Vacancy
        {
            Id = id,
            JobTitle = "Cybernetic Systems Engineer",
            Description = "Responsible for the design and development of intelligent energy systems.",
            SalaryExpectation = 90000,
            ExperienceYears = 5,
            LocationId = kyivLocation?.Id,
            Location = kyivLocation,
            VacancySkills = new List<VacancySkill>
            {
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    VacancyId = id,
                    SkillId = context.Skills.FirstOrDefault(s => s.Name == "Machine Learning")?.Id,
                    Skill = context.Skills.FirstOrDefault(s => s.Name == "Machine Learning"),
                    Level = 8
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    VacancyId = id,
                    SkillId = context.Skills.FirstOrDefault(s => s.Name == "Cyber Security")?.Id,
                    Skill = context.Skills.FirstOrDefault(s => s.Name == "Cyber Security"),
                    Level = 7
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    VacancyId = id,
                    SkillId = context.Skills.FirstOrDefault(s => s.Name == "Machine Learning")?.Id,
                    Skill = context.Skills.FirstOrDefault(s => s.Name == "Machine Learning"),
                    Level = 8
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    VacancyId = id,
                    SkillId = context.Skills.FirstOrDefault(s => s.Name == "Cyber Security")?.Id,
                    Skill = context.Skills.FirstOrDefault(s => s.Name == "Cyber Security"),
                    Level = 7
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    VacancyId = id,
                    SkillId = context.Skills.FirstOrDefault(s => s.Name == "Data Analysis")?.Id,
                    Skill = context.Skills.FirstOrDefault(s => s.Name == "Data Analysis"),
                    Level = 7
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    VacancyId = id,
                    SkillId = context.Skills.FirstOrDefault(s => s.Name == "Embedded Systems")?.Id,
                    Skill = context.Skills.FirstOrDefault(s => s.Name == "Embedded Systems"),
                    Level = 6
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    VacancyId = id,
                    SkillId = context.Skills.FirstOrDefault(s => s.Name == "Artificial Intelligence")?.Id,
                    Skill = context.Skills.FirstOrDefault(s => s.Name == "Artificial Intelligence"),
                    Level = 8
                },
            },
            VacancyCertificates = new List<VacancyCertificate>
            {
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    VacancyId = id,
                    CertificateId = context.Certificates
                        .FirstOrDefault(c => c.Name == "Certified Energy Systems Analyst")?.Id,
                    Certificate = context.Certificates.FirstOrDefault(c => c.Name == "Certified Energy Systems Analyst")
                }
            },
            VacancyLanguageSkills = new List<VacancyLanguageSkill>
            {
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    VacancyId = id,
                    LanguageSkillId = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "English")?.Id,
                    LanguageSkill = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "English"),
                    Level = LanguageLevel.C1
                }
            },
           
        };

        await context.Vacancies.AddAsync(vacancy);
    }

    public static async Task CreateIdealCandidates(ApplicationDatabaseContext context)
    {
        var kyivLocation = context.Locations.FirstOrDefault(l => l.Name == "Kyiv");

        var AlexaId = Guid.NewGuid().ToString();
        var JohnId = Guid.NewGuid().ToString();

        var mostSuitableCandidates = new List<Candidate>
        {
            new()
            {
                Id = AlexaId,
                IdentityId = Guid.NewGuid().ToString(),
                FullName = "Alexa Roberts",
                Description =
                    "Experienced in designing advanced cybernetic systems with a focus on sustainability and innovation.",
                SalaryExpectation = 95000,
                Experience = 7,
                LocationId = kyivLocation.Id,
                Location = kyivLocation,
                CandidateSkills = new List<CandidateSkill>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = AlexaId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "Machine Learning"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Machine Learning").Id,
                        Level = 9
                    },
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = AlexaId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "Cyber Security"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Cyber Security").Id,
                        Level = 8
                    },
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = AlexaId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "Data Analysis"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Data Analysis").Id,
                        Level = 8
                    },
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = AlexaId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "IoT (Internet of Things)"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "IoT (Internet of Things)").Id,
                        Level = 7
                    },
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = AlexaId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "Artificial Intelligence"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Artificial Intelligence").Id,
                        Level = 8
                    }
                },
                CandidateCertificates = new List<CandidateCertificate>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = AlexaId,
                        Certificate =
                            context.Certificates.FirstOrDefault(c => c.Name == "Certified Energy Systems Analyst"),
                        CertificateId = context.Certificates
                            .FirstOrDefault(c => c.Name == "Certified Energy Systems Analyst").Id
                    }
                },
                CandidateLanguageSkills = new List<CandidateLanguageSkill>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = AlexaId,
                        LanguageSkill = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "English"),
                        LanguageSkillId = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "English").Id,
                        Level = LanguageLevel.C1
                    }
                },
                CandidatePublications = new List<CandidatePublication>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = AlexaId,
                        Publication = context.Publications.FirstOrDefault(p => p.Title.Contains("Energy")),
                        PublicationId = context.Publications.FirstOrDefault(p => p.Title.Contains("Energy")).Id
                    }
                }
            },
            new()
            {
                Id = JohnId, // Unique identifier for the new candidate
                IdentityId = Guid.NewGuid().ToString(),
                FullName = "Jordan Taylor",
                Description =
                    "Skilled cybernetic systems designer with expertise in AI-driven energy solutions and system optimization.",
                SalaryExpectation = 92000, // Slightly different salary expectation
                Experience = 6.5, // Slightly less experience than Alexa Roberts
                LocationId = kyivLocation.Id,
                Location = kyivLocation,
                CandidateSkills = new List<CandidateSkill>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = JohnId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "Machine Learning"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Machine Learning").Id,
                        Level = 9 // Same high proficiency in key skill
                    },
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = JohnId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "Cyber Security"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Cyber Security").Id,
                        Level = 7 // Slightly lower than Alexa
                    },
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = JohnId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "Data Analysis"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Data Analysis").Id,
                        Level = 8
                    },
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = JohnId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "IoT (Internet of Things)"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "IoT (Internet of Things)").Id,
                        Level = 6 // Slightly lower proficiency
                    },
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = JohnId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "Artificial Intelligence"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Artificial Intelligence").Id,
                        Level = 8
                    }
                },
                CandidateCertificates = new List<CandidateCertificate>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = JohnId,
                        Certificate =
                            context.Certificates.FirstOrDefault(c => c.Name == "Certified Energy Systems Analyst"),
                        CertificateId = context.Certificates
                            .FirstOrDefault(c => c.Name == "Certified Energy Systems Analyst").Id
                    }
                },
                CandidateLanguageSkills = new List<CandidateLanguageSkill>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = JohnId,
                        LanguageSkill = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "English"),
                        LanguageSkillId = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "English").Id,
                        Level = LanguageLevel.C1 // Same high proficiency in English
                    }
                },
                CandidatePublications = new List<CandidatePublication>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = JohnId,
                        Publication = context.Publications.FirstOrDefault(p => p.Title.Contains("Energy")),
                        PublicationId = context.Publications.FirstOrDefault(p => p.Title.Contains("Energy")).Id
                    }
                }
            }
        };

        await context.AddRangeAsync(mostSuitableCandidates);
    }

    public static async Task CreateDefaultCandidates(ApplicationDatabaseContext context)
    {
        var kyivLocation = context.Locations.FirstOrDefault(l => l.Name == "Kyiv");

        var FirstId = Guid.NewGuid().ToString();
        var SecondId = Guid.NewGuid().ToString();

        var candidates = new List<Candidate>()
        {
            new()
            {
                Id = FirstId,
                IdentityId = Guid.NewGuid().ToString(),
                FullName = "Samuel Green",
                Description =
                    "Competent system analyst with foundational skills in data analysis and basic cyber security protocols.",
                SalaryExpectation = 85000,
                Experience = 4, // Less experience
                LocationId = kyivLocation.Id,
                Location = kyivLocation,
                CandidateSkills = new List<CandidateSkill>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = FirstId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "Data Analysis"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Data Analysis").Id,
                        Level = 6 // Moderate proficiency
                    },
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = FirstId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "Cyber Security"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Cyber Security").Id,
                        Level = 5 // Basic understanding
                    }
                },
                CandidateCertificates = new List<CandidateCertificate>(), // No specific certificates
                CandidateLanguageSkills = new List<CandidateLanguageSkill>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = FirstId,
                        LanguageSkill = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "English"),
                        LanguageSkillId = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "English").Id,
                        Level = LanguageLevel.B2 // Moderate proficiency in English
                    }
                },
                CandidatePublications = new List<CandidatePublication>() // Lacks relevant publications
            },
            new()
            {
                Id = SecondId,
                IdentityId = Guid.NewGuid().ToString(),
                FullName = "Mia Wong",
                Description =
                    "Engineer with a focus on electronics and basic programming skills, eager to expand into cybernetic energy systems.",
                SalaryExpectation = 80000,
                Experience = 3.5, // Developing experience
                LocationId = kyivLocation.Id,
                Location = kyivLocation,
                CandidateSkills = new List<CandidateSkill>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = SecondId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "Embedded Systems"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Embedded Systems").Id,
                        Level = 6 // Relevant but not advanced
                    },
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = SecondId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "Machine Learning"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Machine Learning").Id,
                        Level = 5 // Basic understanding
                    }
                },
                CandidateCertificates = new List<CandidateCertificate>(), // No significant certificates
                CandidateLanguageSkills = new List<CandidateLanguageSkill>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = SecondId,
                        LanguageSkill = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "English"),
                        LanguageSkillId = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "English").Id,
                        Level = LanguageLevel.B1 // Basic proficiency in English
                    }
                },
                CandidatePublications = new List<CandidatePublication>() // No publications
            }
        };

        await context.AddRangeAsync(candidates);
    }

    public static async Task CreateUnsuitableCandidates(ApplicationDatabaseContext context)
    {
        var remoteLocation = context.Locations.FirstOrDefault(l => l.Name == "Remote");

        var FirstId = Guid.NewGuid().ToString();
        var SecondId = Guid.NewGuid().ToString();

        var candidates = new List<Candidate>()
        {
            new()
            {
                Id = FirstId,
                IdentityId = Guid.NewGuid().ToString(),
                FullName = "Chris Johnson",
                Description =
                    "Marketing professional transitioning into tech, with basic knowledge of web development and digital marketing.",
                SalaryExpectation = 70000,
                Experience = 2, // Not relevant to the field
                LocationId = remoteLocation.Id,
                Location = remoteLocation,
                CandidateSkills = new List<CandidateSkill>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = FirstId,
                        Skill = context.Skills.FirstOrDefault(s =>
                            s.Name == "Cloud Computing"), // Assuming context has these as low-relevance skills
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Cloud Computing").Id,
                        Level = 2 // Basic proficiency in unrelated skills
                    }
                },
                CandidateCertificates = new List<CandidateCertificate>(), // No relevant certificates
                CandidateLanguageSkills = new List<CandidateLanguageSkill>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = FirstId,
                        LanguageSkill = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "English"),
                        LanguageSkillId = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "English").Id,
                        Level = LanguageLevel.A2 // Lower proficiency in English
                    }
                },
                CandidatePublications = new List<CandidatePublication>() // No publications
            },
            new()
            {
                Id = SecondId,
                IdentityId = Guid.NewGuid().ToString(),
                FullName = "Lisa Marie",
                Description =
                    "Hospitality manager looking to switch to the tech industry, with a keen interest in technology but no formal technical education.",
                SalaryExpectation = 65000,
                Experience = 2, // Experience in a completely different industry
                LocationId = remoteLocation.Id,
                Location = remoteLocation,
                CandidateSkills = new List<CandidateSkill> // Unrelated skills
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = SecondId,
                        Skill = context.Skills.FirstOrDefault(s => s.Name == "Advanced Algorithms"),
                        SkillId = context.Skills.FirstOrDefault(s => s.Name == "Advanced Algorithms").Id,
                        Level = 3
                    }
                },
                CandidateCertificates = new List<CandidateCertificate>(), // No certificates in tech or related fields
                CandidateLanguageSkills = new List<CandidateLanguageSkill>
                {
                    new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CandidateId = SecondId,
                        LanguageSkill = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "French"),
                        LanguageSkillId = context.LanguageSkills.FirstOrDefault(ls => ls.Name == "French").Id,
                        Level = LanguageLevel.C1 // Fluent in a language not needed for the vacancy
                    }
                },
                CandidatePublications = new List<CandidatePublication>() // No relevant publications
            }
        };

        await context.AddRangeAsync(candidates);
    }
}