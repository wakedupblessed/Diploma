

class JobDTO:
    def __init__(self, salary_expectation, city,required_experience_years, required_skills, language_requirements,
                 publications_required,certificates):
        self.salary_expectation = salary_expectation
        self.city = city
        self.required_experience_years = required_experience_years
        self.required_skills = required_skills
        self.language_requirements = language_requirements
        self.publications_required = publications_required
        self.certificates = certificates


class CandidateDTO(JobDTO):
    pass  # Inherits everything from JobDTO, assuming candidates have the same structure.


job_data = {
    "job_title": "Лабораторія кібер-енергетичних систем",
    "salary_expectation": 70000,
    "city": "Київ",
    "experience_years": 3,
    "skills": {
        "programming": 6,
        "data_analysis": 8,
        "machine_learning": 6
    },
    "languages": {
        "English": "B2",
        "German": "A2"
    },
    "publications": 2,
    "certificates": ["Certified Data Scientist", "Certified AI Specialist"]
}

candidates = [
    {
        "name": "Андрій Коваленко",
        "salary_expectation": 65000,
        "city": "Київ",
        "experience_years": 4,
        "skills": {
            "programming": 7,
            "data_analysis": 8,
            "machine_learning": 6,
            "cyber_security": 3
        },
        "languages": {
            "English": "C1"
        },
        "publications": 3,
        "certificates": ["Certified Data Scientist"]
    },
    {
        "name": "Ірина Шевченко",
        "salary_expectation": 75000,
        "city": "Київ",
        "experience_years": 5,
        "skills": {
            "programming": 6,
            "data_analysis": 8,
            "machine_learning": 9
        },
        "languages": {
            "English": "B2",
            "German": "A2"
        },
        "publications": 1,
        "certificates": ["Certified AI Specialist", "Project Management Professional"]
    },
    {
        "name": "Олексій Петренко",
        "salary_expectation": 68000,
        "city": "Одеса",
        "experience_years": 3,
        "skills": {
            "programming": 6,
            "data_analysis": 6,
            "machine_learning": 6,
            "electronics": 5
        },
        "languages": {
            "English": "B1"
        },
        "publications": 2,
        "certificates": ["Certified Data Scientist"]
    },
    {
        "name": "Марія Березовська",
        "salary_expectation": 69000,
        "city": "Київ",
        "experience_years": 4,
        "skills": {
            "programming": 7,
            "data_analysis": 9,
            "machine_learning": 7
        },
        "languages": {
            "English": "C1",
            "German": "A2"
        },
        "publications": 3,
        "certificates": ["Certified Data Scientist", "Certified AI Specialist"]
    },
    {
        "name": "Сергій Назаренко",
        "salary_expectation": 71000,
        "city": "Київ",
        "experience_years": 5,
        "skills": {
            "programming": 6,
            "data_analysis": 8,
            "machine_learning": 6
        },
        "languages": {
            "English": "B2",
            "German": "B1"
        },
        "publications": 2,
        "certificates": ["Certified Data Scientist"]
    },
    {
        "name": "Олена Ткаченко",
        "salary_expectation": 60000,
        "city": "Одеса",
        "experience_years": 2,
        "skills": {
            "programming": 5,
            "data_analysis": 7,
            "machine_learning": 5
        },
        "languages": {
            "English": "A2"
        },
        "publications": 1,
        "certificates": []
    },
    {
        "name": "Віктор Поліщук",
        "salary_expectation": 75000,
        "city": "Київ",
        "experience_years": 3,
        "skills": {
            "programming": 5,
            "data_analysis": 6,
            "machine_learning": 4
        },
        "languages": {
            "English": "B1",
            "German": "A1"
        },
        "publications": 0,
        "certificates": []
    },
    {
        "name": "Анатолій Вербенко",
        "salary_expectation": 85000,
        "city": "Львів",
        "experience_years": 1,
        "skills": {
            "programming": 3,
            "data_analysis": 4,
            "machine_learning": 2
        },
        "languages": {
            "English": "A1"
        },
        "publications": 0,
        "certificates": []
    },
    {
        "name": "Іванна Кручко",
        "salary_expectation": 50000,
        "city": "Харків",
        "experience_years": 1,
        "skills": {
            "programming": 2,
            "data_analysis": 3,
            "machine_learning": 1
        },
        "languages": {
            "English": "B1",
            "German": "A1"
        },
        "publications": 5,
        "certificates": ["Certified Project Manager"]
    },
    {
        "name": "Денис Сухомлин",
        "salary_expectation": 65000,
        "city": "Дніпро",
        "experience_years": 1,
        "skills": {
            "programming": 1,
            "data_analysis": 3,
            "machine_learning": 1
        },
        "languages": {
            "English": "A2",
            "German": "A1"
        },
        "publications": 2,
        "certificates": ["Certified Network Engineer"]
    }
]
