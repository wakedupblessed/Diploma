using Diploma.Domain.Features;

namespace Persistence;

public static class Data
{
    public static List<Location> Locations = new()
    {
        new()
        {
            Name = "Kyiv",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Kharkiv",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Odesa",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Dnipro",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Lviv",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Zaporizhzhia",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Remote",
            Id = Guid.NewGuid().ToString()
        }
    };

    public static List<Skill> Skills = new()
    {
        new()
        {
            Name = "Python",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Machine Learning",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Data Analysis",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Cyber Security",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Artificial Intelligence",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Big Data Technologies",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "C++",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Java",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "MATLAB",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Simulation and Modeling",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Database Management",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Blockchain Technology",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "IoT (Internet of Things)",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Embedded Systems",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Energy Systems Analysis",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Advanced Algorithms",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Statistical Analysis",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Cloud Computing",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Distributed Systems",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Quantum Computing",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Circuit Design",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Renewable Energy Systems",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Power System Engineering",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "SCADA Systems",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "High Performance Computing",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Security Protocols",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Software Development Life Cycle (SDLC)",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Virtualization Technologies",
            Id = Guid.NewGuid().ToString()
        },
        new()
        {
            Name = "Neural Networks",
            Id = Guid.NewGuid().ToString()
        }
    };

    public static List<LanguageSkill> LanguageSkills = new()
    {
        new LanguageSkill
        {
            Id = Guid.NewGuid().ToString(),
            Name = "English" 
        },
        new LanguageSkill
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Ukrainian"
        },
        new LanguageSkill
        {
            Id = Guid.NewGuid().ToString(),
            Name = "German"
        },
        new LanguageSkill
        {
            Id = Guid.NewGuid().ToString(),
            Name = "French"
        },
        new LanguageSkill
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Spanish"
        },
        new LanguageSkill
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Polish"
        }
    };
    
    public static List<Company> Companies = new()
    {
        new Company
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Cybernetic Energy Solutions"
        },
        new Company
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Advanced Energy Dynamics"
        },
        new Company
        {
            Id = Guid.NewGuid().ToString(),
            Name = "GreenTech Innovations"
        },
        new Company
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Quantum Energy Systems"
        },
        new Company
        {
            Id = Guid.NewGuid().ToString(),
            Name = "IntelliPower Labs"
        }
    };
    
    public static List<Certificate> Certificates = new()
    {
        new Certificate
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Certified Data Scientist",
            CompanyId = Companies[0].Id,  
            Company = Companies[0]
        },
        new Certificate
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Advanced Cyber Security Certification",
            CompanyId = Companies[1].Id,  
            Company = Companies[1]
        },
        new Certificate
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Machine Learning Expert",
            CompanyId = Companies[2].Id,  
            Company = Companies[2]
        },
        new Certificate
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Certified Energy Systems Analyst",
            CompanyId = Companies[3].Id,  
            Company = Companies[3]
        },
        new Certificate
        {
            Id = Guid.NewGuid().ToString(),
            Name = "IoT Systems Professional",
            CompanyId = Companies[4].Id,
            Company = Companies[4]
        },
        new Certificate
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Renewable Energy Technology Specialist",
            CompanyId = Companies[2].Id, 
            Company = Companies[2]
        }
    };
    
    public static List<Publication> Publications = new()
    {
        new Publication
        {
            Id = Guid.NewGuid().ToString(),
            Title = "Enhancing Grid Stability with AI-Based Predictive Maintenance",
            JournalName = "Journal of Smart Grid Technologies",
            Doi = "10.1001/jsgt.2023.0328",
            YearOfPublication = 2023
        },
        new Publication
        {
            Id = Guid.NewGuid().ToString(),
            Title = "Cybersecurity Challenges in Modern Energy Systems",
            JournalName = "International Journal of Energy Security",
            Doi = "10.1001/ijes.2023.0474",
            YearOfPublication = 2023
        },
        new Publication
        {
            Id = Guid.NewGuid().ToString(),
            Title = "Machine Learning Applications in Renewable Energy Forecasting",
            JournalName = "Renewable Energy Advances",
            Doi = "10.1001/rea.2023.0586",
            YearOfPublication = 2023
        },
        new Publication
        {
            Id = Guid.NewGuid().ToString(),
            Title = "The Impact of Quantum Computing on Energy Sector Optimization",
            JournalName = "Quantum Reviews",
            Doi = "10.1001/qr.2023.0983",
            YearOfPublication = 2023
        },
        new Publication
        {
            Id = Guid.NewGuid().ToString(),
            Title = "Real-Time Data Analytics for Enhanced Energy Distribution",
            JournalName = "Energy Systems Journal",
            Doi = "10.1001/esj.2023.1234",
            YearOfPublication = 2023
        }
    };
}