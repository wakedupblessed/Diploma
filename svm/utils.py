import numpy as np
from datetime import datetime
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.preprocessing import MinMaxScaler
from data import *


def dict_to_dto(data):
    return JobDTO(
        salary_expectation=data["salary_expectation"],
        city=data["city"],
        required_experience_years=data["experience_years"],
        required_skills=data["skills"],
        language_requirements=data["languages"],
        publications_required=data["publications"],
        certificates=data["certificates"]
    )


def dto_to_features(dto, job_dto):
    language_levels = {"A1": 1, "A2": 2, "B1": 3, "B2": 4, "C1": 5, "C2": 6}

    city_feature = [1 if dto.city == job_dto.city else 0]

    features = [
                   dto.salary_expectation,
                   dto.required_experience_years,
                   dto.required_skills['programming'],
                   dto.required_skills['data_analysis'],
                   dto.required_skills['machine_learning'],
                   dto.publications_required
               ] + city_feature

    # Language features
    language_features = []
    for lang in ['English', 'German', 'French', 'Spanish']:  # Add other languages as needed
        language_features.append(language_levels.get(dto.language_requirements.get(lang, 'A1'), 0))

    certificate_score_feature = [certificate_score(dto.certificates, job_dto.certificates)]

    # Combine all features into one list
    return features + language_features + certificate_score_feature



def scale_experience(experience):
    scaler = MinMaxScaler(feature_range=(0, 10))  # Scale to a similar range as skills
    return scaler.fit_transform(np.array(experience).reshape(-1, 1)).flatten()


def normalize_vector(vector):
    norm = np.linalg.norm(vector)
    if norm == 0:
        return vector
    return vector / norm


def calculate_decay(year):
    current_year = datetime.now().year
    years_since_certification = current_year - year
    # Assuming a certification loses 10% of its initial relevance each year
    decay_factor = max(0, 1 - 0.1 * years_since_certification)
    return decay_factor


def create_skill_vector(skills_info, mandatory_skills):
    skill_levels = []
    skill_weights = []
    for skill_details in skills_info:
        skill_name = skill_details["name"]
        skill_level = skill_details["level"]
        weight = 1.5 if skill_name in mandatory_skills else 1.0
        skill_levels.append(skill_level)
        skill_weights.append(weight)
    return np.array(skill_levels) * np.array(skill_weights)


def create_job_skill_vector(candidate_skills_info, mandatory_skills, optional_skill_value=1):
    job_skills = []
    for skill_details in candidate_skills_info:
        if skill_details['name'] in mandatory_skills:
            job_skills.append(10)  # Mandatory skills get the highest value
        else:
            job_skills.append(optional_skill_value) # Optional skills get a lower value as a small bonus

    return np.array(job_skills)


def create_certification_vector(certifications):
    return np.array([calculate_decay(int(cert["date"][:4])) for cert in certifications])


def calculate_years_experience(start, end, role_weight):
    start_date = datetime.strptime(start, "%Y-%m")
    end_date = datetime.strptime(end, "%Y-%m")
    years = (end_date.year - start_date.year) + ((end_date.month - start_date.month) / 12)
    return years * role_weight


def certificate_score(candidate_certs, job_certs):
    # Assign points for each matching certificate and smaller points for extra certificates
    match_score = 1.0
    extra_cert_score = 0.1  # Bonus points for additional certificates not listed in the job description

    score = 0
    job_cert_set = set(job_certs)
    candidate_cert_set = set(candidate_certs)

    # Points for certificates required by the job that the candidate has
    score += sum(match_score for cert in candidate_cert_set if cert in job_cert_set)

    # Bonus points for additional certificates the candidate has beyond the job requirements
    if not job_certs:  # If no specific certificates are required, every cert is a bonus
        score += len(candidate_cert_set) * extra_cert_score
    else:
        score += sum(extra_cert_score for cert in candidate_cert_set if cert not in job_cert_set)

    return score