

class SvmDTO:
    def __init__(self, description, salary_expectation, city,required_experience_years, required_skills, language_requirements,
                 publications_required,certificates, education):
        self.description = description
        self.salary_expectation = salary_expectation
        self.city = city
        self.required_experience_years = required_experience_years
        self.required_skills = required_skills
        self.language_requirements = language_requirements
        self.publications_required = publications_required
        self.certificates = certificates
        self.education = education


job_data = {
  "job_title": "Cyber-Energy Systems Developer",
  "description": "Приєднуйтесь до нашої передової лабораторії, яка спеціалізується на інтеграції кібербезпеки з енергетичними системами. Ця роль вимагає розробки безпечних програмних рішень, використання машинного навчання для оптимізації енергоспоживання та інтеграції IoT з хмарними платформами для підвищення безпеки та ефективності енергетичної системи.",
  "salary_expectation": 70000,
  "city": "Київ",
  "experience_years": 3,
  "skills": {
    "Machine Learning": 3,
    "IoT (Internet of Things)": 2,
    "Cloud Computing": 3,
    "Cyber Security": 4,
    "Data Analysis": 3,
    "SCADA Systems": 2
  },
  "languages": {
    "English": "B2",
    "German": "A2"
  },
  "publications": 0,
  "certificates": [
    "Certified Data Scientist",
    "Advanced Cyber Security Certification",
    "IoT Systems Professional"
  ],
  "education": {
    "level": 2,
    "name": "Computer Science"
  }
}

candidates = [
  {
    "name": "Candidate 1",
    "description": "Досвідчений у створенні масштабованих хмарних рішень та впровадженні надійних заходів кібербезпеки.",
    "salary_expectation": 72000,
    "city": "Київ",
    "experience_years": 4,
    "skills": {
      "Machine Learning": 3,
      "IoT (Internet of Things)": 2,
      "Cloud Computing": 4,
      "Cyber Security": 5,
      "Data Analysis": 3,
      "SCADA Systems": 3
    },
    "languages": {
      "English": "C1",
      "German": "B1"
    },
    "publications": 3,
    "certificates": [
      "Certified Data Scientist",
      "Advanced Cyber Security Certification"
    ],
"education": {
    "level": 2,
    "name": "Computer Science"
  }
  },
  {
    "name": "Candidate 2",
    "description": "Зосереджений на оптимізації енергетичних систем за допомогою передових технік машинного навчання",
    "salary_expectation": 70000,
    "city": "Васильків",
    "experience_years": 3,
    "skills": {
      "Machine Learning": 4,
      "IoT (Internet of Things)": 3,
      "Cloud Computing": 3,
      "Cyber Security": 3,
      "Data Analysis": 4,
      "SCADA Systems": 2
    },
    "languages": {
      "English": "C1",
      "German": "A2"
    },
    "publications": 2,
    "certificates": [
      "Certified Data Scientist",
      "IoT Systems Professional"
    ], "education": {
    "level": 2,
    "name": "Computer Science"
  }
  },
  {
    "name": "Candidate 3",
    "description": "Кваліфікований у розгортанні IoT-рішень для управління енергією з міцним фундаментом у хмарних архітектурах.",
    "salary_expectation": 71000,
    "city": "Буча",
    "experience_years": 3,
    "skills": {
      "Machine Learning": 3,
      "IoT (Internet of Things)": 4,
      "Cloud Computing": 3,
      "Cyber Security": 4,
      "Data Analysis": 3,
      "SCADA Systems": 1
    },
    "languages": {
      "English": "B2",
      "German": "B1"
    },
    "publications": 2,
    "certificates": [
      "Advanced Cyber Security Certification",
      "IoT Systems Professional"
    ], "education": {
    "level": 2,
    "name": "Computer Science"
  }
  },
  {
    "name": "Candidate 4",
    "description": "Експерт з протоколів кібербезпеки з широким досвідом у хмарних обчисленнях та аналізі даних.",
    "salary_expectation": 73000,
    "city": "Бровари",
    "experience_years": 5,
    "skills": {
      "Machine Learning": 3,
      "IoT (Internet of Things)": 2,
      "Cloud Computing": 5,
      "Cyber Security": 5,
      "Data Analysis": 4,
      "SCADA Systems": 2
    },
    "languages": {
      "English": "C1"
    },
    "publications": 3,
    "certificates": [
      "Advanced Cyber Security Certification",
      "Certified Data Scientist"
    ], "education": {
    "level": 2,
    "name": "Computer Science"
  }
  },
  {
    "name": "Candidate 5",
    "description": "Інноватор у застосуванні машинного навчання для енергетичних систем, кваліфікований у статистичному та аналізі даних",
    "salary_expectation": 68000,
    "city": "Irpin",
    "experience_years": 3,
    "skills": {
      "Machine Learning": 5,
      "IoT (Internet of Things)": 2,
      "Cloud Computing": 3,
      "Cyber Security": 3,
      "Data Analysis": 5,
      "SCADA Systems": 2
    },
    "languages": {
      "English": "B2",
      "Ukrainian": "C2"
    },
    "publications": 2,
    "certificates": [
      "Certified Data Scientist"
    ], "education": {
    "level": 2,
    "name": "Computer Science"
  }
  },
  {
    "name": "Candidate 6",
    "description": "Досвідчений у системах SCADA для управління енергією, з міцними навичками у хмарних технологіях та безпеці.",
    "salary_expectation": 70000,
    "city": "Київ",
    "experience_years": 4,
    "skills": {
      "Machine Learning": 3,
      "IoT (Internet of Things)": 3,
      "Cloud Computing": 4,
      "Cyber Security": 4,
      "Data Analysis": 3,
      "SCADA Systems": 4
    },
    "languages": {
      "English": "B2",
      "Polish": "A2"
    },
    "publications": 1,
    "certificates": [
      "IoT Systems Professional",
      "Advanced Cyber Security Certification"
    ], "education": {
    "level": 2,
    "name": "Computer Science"
  }
  },
  {
    "name": "Candidate 7",
    "description": "Наполегливий у покращенні заходів кібернетичної та фізичної безпеки в енергетичних системах за допомогою передових обчислювальних технік",
    "salary_expectation": 69000,
    "city": "Київ",
    "experience_years": 3,
    "skills": {
      "Machine Learning": 3,
      "IoT (Internet of Things)": 2,
      "Cloud Computing": 3,
      "Cyber Security": 5,
      "Data Analysis": 4,
      "SCADA Systems": 3
    },
    "languages": {
      "English": "B2",
      "German": "A2",
      "Ukrainian": "C2"
    },
    "publications": 2,
    "certificates": [
      "Certified Data Scientist",
      "Advanced Cyber Security Certification"
    ], "education": {
    "level": 2,
    "name": "Computer Science"
  }
  },
  {
    "name": "Candidate 8",
    "description": "Спеціаліст з хмарних обчислень, який фокусується на безпечній інтеграції IoT та аналізі даних для оптимізації енергії.",
    "salary_expectation": 72000,
    "city": "Київ",
    "experience_years": 3,
    "skills": {
      "Machine Learning": 2,
      "IoT (Internet of Things)": 3,
      "Cloud Computing": 5,
      "Cyber Security": 4,
      "Data Analysis": 3,
      "SCADA Systems": 2
    },
    "languages": {
      "English": "C1",
      "French": "B1"
    },
    "publications": 1,
    "certificates": [
      "IoT Systems Professional",
      "Certified Data Scientist"
    ] , "education": {
    "level": 2,
    "name": "Computer Science"
  }
  },
  {
    "name": "Candidate 9",
    "description": "Експерт з кібербезпеки з всеосяжним знанням енергетичних систем, кваліфікований у впровадженні надійних захисних заходів",
    "salary_expectation": 71000,
    "city": "Київ",
    "experience_years": 5,
    "skills": {
      "Machine Learning": 4,
      "IoT (Internet of Things)": 2,
      "Cloud Computing": 4,
      "Cyber Security": 6,
      "Data Analysis": 4,
      "SCADA Systems": 3
    },
    "languages": {
      "English": "B2",
      "Spanish": "A2"
    },
    "publications": 3,
    "certificates": [
      "Advanced Cyber Security Certification",
      "Certified Data Scientist"
    ], "education": {
    "level": 2,
    "name": "Computer Science"
  }
  },
  {
    "name": "Candidate 10",
    "description": "Ентузіаст IoT та хмарних обчислень із глибоким прихильністю до використання технологій для сталого розвитку енергетичних рішень.",
    "salary_expectation": 70000,
    "city": "Київ",
    "experience_years": 3,
    "skills": {
      "Machine Learning": 3,
      "IoT (Internet of Things)": 4,
      "Cloud Computing": 4,
      "Cyber Security": 3,
      "Data Analysis": 3,
      "SCADA Systems": 2
    },
    "languages": {
      "English": "C1",
      "Polish": "B1"
    },
    "publications": 2,
    "certificates": [
      "IoT Systems Professional",
      "Certified Data Scientist"
    ] , "education": {
    "level": 2,
    "name": "Computer Science"
  }
  },
  {
    "name": "Candidate 11",
    "description": "Має базові знання у галузі хмарних обчислень та IoT, з досвідом роботи над малими проектами.",
    "salary_expectation": 68000,
    "city": "Буча",
    "experience_years": 2,
    "skills": {
      "Machine Learning": 2,
      "IoT (Internet of Things)": 2,
      "Cloud Computing": 2,
      "Cyber Security": 1,
      "Data Analysis": 2,
      "SCADA Systems": 1
    },
    "languages": {
      "English": "B1",
      "Ukrainian": "C2"
    },
    "publications": 1,
    "certificates": [] ,
"education": {
    "level": 1,
    "name": "Computer Science"
  }
  },
  {
    "name": "Candidate 12",
    "description": "Досвід роботи з аналізом даних і базові знання з кібербезпеки.",
    "salary_expectation": 66000,
    "city": "Ірпінь",
    "experience_years": 3,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 1,
      "Cyber Security": 2,
      "Data Analysis": 3,
      "SCADA Systems": 1
    },
    "languages": {
      "English": "B2"
    },
    "publications": 1,
    "certificates": ["IoT Systems Professional"]
  },
  {
    "name": "Candidate 13",
    "description": "Професіонал у сфері машинного навчання, що шукає можливості для застосування своїх навичок у нових галузях.",
    "salary_expectation": 65000,
    "city": "Вишневе",
    "experience_years": 2,
    "skills": {
      "Machine Learning": 3,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 1,
      "Cyber Security": 1,
      "Data Analysis": 2,
      "SCADA Systems": 1
    },
    "languages": {
      "English": "A2",
      "Ukrainian": "C2"
    },
    "publications": 0,
    "certificates": ["Certified Data Scientist"]
  },
  {
    "name": "Candidate 14",
    "description": "Енергетичний інженер із досвідом у хмарних технологіях, шукає перехід у кібербезпеку.",
    "salary_expectation": 64000,
    "city": "Бориспіль",
    "experience_years": 4,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 2,
      "Cloud Computing": 3,
      "Cyber Security": 2,
      "Data Analysis": 2,
      "SCADA Systems": 2
    },
    "languages": {
      "English": "B1",
      "Ukrainian": "C2"
    },
    "publications": 2,
    "certificates": ["Advanced Cyber Security Certification"]
  },
  {
    "name": "Candidate 15",
    "description": "Інженер-програміст з досвідом у IoT, зацікавлений у розширенні своїх знань у машинному навчанні.",
    "salary_expectation": 67000,
    "city": "Фастів",
    "experience_years": 3,
    "skills": {
      "Machine Learning": 2,
      "IoT (Internet of Things)": 3,
      "Cloud Computing": 2,
      "Cyber Security": 1,
      "Data Analysis": 2,
      "SCADA Systems": 1
    },
    "languages": {
      "English": "B2",
      "Ukrainian": "C2"
    },
    "publications": 1,
    "certificates": []
  },
  {
    "name": "Candidate 16",
    "description": "Спеціаліст з кібербезпеки, із базовими навичками у хмарних обчисленнях та аналізі даних.",
    "salary_expectation": 65000,
    "city": "Кагарлик",
    "experience_years": 3,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 2,
      "Cyber Security": 3,
      "Data Analysis": 3,
      "SCADA Systems": 1
    },
    "languages": {
      "English": "B1"
    },
    "publications": 1,
    "certificates": ["Advanced Cyber Security Certification"]
  },
  {
    "name": "Candidate 17",
    "description": "Молодий інженер з досвідом у SCADA системах, хоче розвивати навички у кібербезпеці.",
    "salary_expectation": 65000,
    "city": "Переяслав",
    "experience_years": 2,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 2,
      "Cyber Security": 2,
      "Data Analysis": 1,
      "SCADA Systems": 3
    },
    "languages": {
      "English": "B2"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 18",
    "description": "Інженер з досвідом роботи у кібербезпеці та хмарних обчисленнях, шукає можливості у сфері IoT.",
    "salary_expectation": 69000,
    "city": "Славутич",
    "experience_years": 3,
    "skills": {
      "Machine Learning": 2,
      "IoT (Internet of Things)": 3,
      "Cloud Computing": 2,
      "Cyber Security": 2,
      "Data Analysis": 1,
      "SCADA Systems": 2
    },
    "languages": {
      "English": "C1"
    },
    "publications": 2,
    "certificates": ["IoT Systems Professional"]
  },
  {
    "name": "Candidate 19",
    "description": "Програміст з базовими знаннями у SCADA та IoT, хоче поглибити навички у хмарних технологіях.",
    "salary_expectation": 63000,
    "city": "Боярка",
    "experience_years": 1,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 2,
      "Cloud Computing": 2,
      "Cyber Security": 1,
      "Data Analysis": 1,
      "SCADA Systems": 2
    },
    "languages": {
      "English": "A2",
      "Ukrainian": "C2"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 20",
    "description": "Має досвід у машинному навчанні, інтерес до кібербезпеки та розвитку навичок у IoT.",
    "salary_expectation": 66000,
    "city": "Обухів",
    "experience_years": 3,
    "skills": {
      "Machine Learning": 3,
      "IoT (Internet of Things)": 2,
      "Cloud Computing": 1,
      "Cyber Security": 2,
      "Data Analysis": 2,
      "SCADA Systems": 1
    },
    "languages": {
      "English": "B1"
    },
    "publications": 1,
    "certificates": ["Certified Data Scientist"]
  },
  {
    "name": "Candidate 21",
    "description": "Фахівець з маркетингу з основним досвідом у соціальних медіа та рекламі.",
    "salary_expectation": 55000,
    "city": "Чернівці",
    "experience_years": 5,
    "skills": {
      "Social Media": 4,
      "Advertising": 3,
      "Content Creation": 3
    },
    "languages": {
      "English": "B1"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 22",
    "description": "Шеф-кухар з великим досвідом у веденні ресторану і створенні меню.",
    "salary_expectation": 60000,
    "city": "Луцьк",
    "experience_years": 10,
    "skills": {
      "Culinary Arts": 5,
      "Menu Planning": 5,
      "Food Safety": 4
    },
    "languages": {
      "Ukrainian": "C2"
    },
    "publications": 0,
    "certificates": ["Food Safety Certification"]
  },
  {
    "name": "Candidate 23",
    "description": "Музикант, який спеціалізується на класичній гітарі та композиції.",
    "salary_expectation": 45000,
    "city": "Івано-Франківськ",
    "experience_years": 8,
    "skills": {
      "Music Composition": 5,
      "Guitar Playing": 5,
      "Sound Engineering": 3
    },
    "languages": {
      "Polish": "B1"
    },
    "publications": 3,
    "certificates": ["Music Theory Certificate"]
  },
  {
    "name": "Candidate 24",
    "description": "Бухгалтер з досвідом у фінансовому звітуванні та податковому плануванні.",
    "salary_expectation": 65000,
    "city": "Рівне",
    "experience_years": 7,
    "skills": {
      "Financial Reporting": 5,
      "Tax Planning": 4,
      "Accounting": 5
    },
    "languages": {
      "Russian": "C1"
    },
    "publications": 0,
    "certificates": ["Certified Public Accountant"]
  },
  {
    "name": "Candidate 25",
    "description": "Гід в туристичній агенції з досвідом роботи в Європі та Північній Америці.",
    "salary_expectation": 50000,
    "city": "Кам'янець-Подільський",
    "experience_years": 6,
    "skills": {
      "Tour Guiding": 4,
      "Travel Planning": 4,
      "Customer Service": 5
    },
    "languages": {
      "Spanish": "C1",
      "German": "B2"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 26",
    "description": "Журналіст з інтересом до міжнародних новин та політичних подій.",
    "salary_expectation": 58000,
    "city": "Суми",
    "experience_years": 4,
    "skills": {
      "Journalism": 4,
      "Editing": 4,
      "Reporting": 4
    },
    "languages": {
      "English": "C1"
    },
    "publications": 5,
    "certificates": []
  },
  {
    "name": "Candidate 27",
    "description": "Фітнес тренер з сертифікацією та досвідом в особистих тренуваннях та реабілітації.",
    "salary_expectation": 47000,
    "city": "Черкаси",
    "experience_years": 3,
    "skills": {
      "Personal Training": 5,
      "Rehabilitation": 3,
      "Nutrition Planning": 4
    },
    "languages": {
      "Ukrainian": "C2"
    },
    "publications": 0,
    "certificates": ["Certified Personal Trainer"]
  },
  {
    "name": "Candidate 28",
    "description": "Викладач англійської мови з досвідом роботи в середніх школах та приватних курсах.",
    "salary_expectation": 52000,
    "city": "Миколаїв",
    "experience_years": 5,
    "skills": {
      "Teaching": 5,
      "Curriculum Development": 4,
      "Educational Assessment": 4
    },
    "languages": {
      "English": "C2",
      "Ukrainian": "C2"
    },
    "publications": 1,
    "certificates": ["TEFL Certification"]
  },
  {
    "name": "Candidate 29",
    "description": "Менеджер проектів в галузі будівництва з досвідом управління багатомільйонними проектами.",
    "salary_expectation": 70000,
    "city": "Тернопіль",
    "experience_years": 9,
    "skills": {
      "Project Management": 5,
      "Cost Estimation": 4,
      "Construction Planning": 5
    },
    "languages": {
      "Russian": "B2"
    },
    "publications": 0,
    "certificates": ["Project Management Professional"]
  },
  {
    "name": "Candidate 30",
    "description": "Менеджер з продажу з досвідом у банківському секторі, спеціалізується на кредитних продуктах.",
    "salary_expectation": 55000,
    "city": "Херсон",
    "experience_years": 8,
    "skills": {
      "Sales Management": 5,
      "Customer Relations": 5,
      "Financial Services": 4
    },
    "languages": {
      "Ukrainian": "C2",
      "English": "B1"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 31",
    "description": "Початківець програміст з базовими навичками у машинному навчанні та IoT.",
    "salary_expectation": 50000,
    "city": "Васильків",
    "experience_years": 1,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 1,
      "Cyber Security": 1,
      "Data Analysis": 1,
      "SCADA Systems": 1
    },
    "languages": {
      "Ukrainian": "C2",
      "English": "A1"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 32",
    "description": "Дослідник у галузі даних з мінімальним досвідом у застосуванні машинного навчання.",
    "salary_expectation": 52000,
    "city": "Біла Церква",
    "experience_years": 1,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 1,
      "Cyber Security": 1,
      "Data Analysis": 2,
      "SCADA Systems": 1
    },
    "languages": {
      "English": "A2"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 33",
    "description": "Технічний спеціаліст з невеликим досвідом роботи в хмарних обчисленнях та кібербезпеці.",
    "salary_expectation": 48000,
    "city": "Київ",
    "experience_years": 1,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 1,
      "Cyber Security": 2,
      "Data Analysis": 1,
      "SCADA Systems": 1
    },
    "languages": {
      "Ukrainian": "C2",
      "English": "B1"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 34",
    "description": "ІТ стажер із базовими знаннями в IoT та кібербезпеці, шукає можливості для розвитку.",
    "salary_expectation": 47000,
    "city": "Чернігів",
    "experience_years": 1,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 1,
      "Cyber Security": 1,
      "Data Analysis": 1,
      "SCADA Systems": 1
    },
    "languages": {
      "Russian": "B1",
      "English": "A2"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 35",
    "description": "Новачок у програмуванні з зацікавленням в машинному навчанні та аналізі даних.",
    "salary_expectation": 45000,
    "city": "Житомир",
    "experience_years": 1,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 1,
      "Cyber Security": 1,
      "Data Analysis": 1,
      "SCADA Systems": 1
    },
    "languages": {
      "Ukrainian": "C2",
      "English": "A1"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 36",
    "description": "Спеціаліст із встановлення програмного забезпечення із базовими знаннями у кібербезпеці.",
    "salary_expectation": 49000,
    "city": "Умань",
    "experience_years": 1,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 1,
      "Cyber Security": 2,
      "Data Analysis": 1,
      "SCADA Systems": 1
    },
    "languages": {
      "Russian": "C1",
      "English": "A2"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 37",
    "description": "Випускник із ступенем бакалавра у галузі інформатики, із початковими знаннями хмарних обчислень.",
    "salary_expectation": 46000,
    "city": "Одеса",
    "experience_years": 1,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 1,
      "Cyber Security": 1,
      "Data Analysis": 1,
      "SCADA Systems": 1
    },
    "languages": {
      "Ukrainian": "C2",
      "English": "B1"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 38",
    "description": "Молодий професіонал з незначним досвідом у використанні IoT для промислових застосувань.",
    "salary_expectation": 51000,
    "city": "Суми",
    "experience_years": 1,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 1,
      "Cyber Security": 1,
      "Data Analysis": 1,
      "SCADA Systems": 1
    },
    "languages": {
      "Ukrainian": "C2",
      "English": "A1"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 39",
    "description": "Інженер-початківець із зацікавленням у кібербезпеці, має невеликий досвід роботи з хмарними технологіями.",
    "salary_expectation": 50000,
    "city": "Мелітополь",
    "experience_years": 1,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 1,
      "Cyber Security": 1,
      "Data Analysis": 1,
      "SCADA Systems": 1
    },
    "languages": {
      "Ukrainian": "C2",
      "English": "A2"
    },
    "publications": 0,
    "certificates": []
  },
  {
    "name": "Candidate 40",
    "description": "Початківець у програмуванні з інтересом до розробки програмного забезпечення та базовими знаннями у IoT.",
    "salary_expectation": 48000,
    "city": "Кропивницький",
    "experience_years": 1,
    "skills": {
      "Machine Learning": 1,
      "IoT (Internet of Things)": 1,
      "Cloud Computing": 1,
      "Cyber Security": 1,
      "Data Analysis": 1,
      "SCADA Systems": 1
    },
    "languages": {
      "Ukrainian": "C2",
      "English": "A1"
    },
    "publications": 0,
    "certificates": []
  }
]

