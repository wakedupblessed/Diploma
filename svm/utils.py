import random

import numpy as np
from sklearn.preprocessing import MinMaxScaler

from data import *


def dict_to_dto(data):
    return SvmDTO(
        salary_expectation=data["salary_expectation"],
        city=data["city"],
        required_experience_years=data["experience_years"],
        required_skills=data["skills"],
        language_requirements=data["languages"],
        publications_required=data["publications"],
        certificates=data["certificates"]
    )


def build_feature_index(candidates, job):
    all_skills = set()
    all_languages = set()
    all_certificates = set()

    # Collect skills, languages, and certificates from candidates
    for candidate in candidates:
        all_skills.update(candidate.required_skills.keys())
        all_languages.update(candidate.language_requirements.keys())
        all_certificates.update(candidate.certificates)

    # Also add job description skills, languages, and certificates
    all_skills.update(job.required_skills.keys())
    all_languages.update(job.language_requirements.keys())
    all_certificates.update(job.certificates)

    # Create index maps for dynamic features
    skill_index = {skill: i for i, skill in enumerate(sorted(all_skills))}
    language_index = {lang: len(skill_index) + i for i, lang in enumerate(sorted(all_languages))}
    certificate_index = {cert: len(skill_index) + len(language_index) + i for i, cert in enumerate(sorted(all_certificates))}

    return skill_index, language_index, certificate_index


def dto_to_features(dto, job_dto, weights, skill_index, language_index, certificate_index):
    total_features = len(skill_index) + len(language_index) + len(certificate_index) + 4  # +4 for the new features
    features = np.zeros(total_features)

    # Encoding Skills
    for skill, level in dto.required_skills.items():
        if skill in skill_index:
            idx = skill_index[skill]
            features[idx] = level * weights[idx]

    # Encoding Languages
    for lang, proficiency in dto.language_requirements.items():
        if lang in language_index:
            idx = language_index[lang]
            level = {"A1": 1, "A2": 2, "B1": 3, "B2": 4, "C1": 5, "C2": 6}.get(proficiency, 0)
            features[idx] = level * weights[idx]

    # Encoding Certificates
    for cert in dto.certificates:
        if cert in certificate_index:
            idx = certificate_index[cert]
            features[idx] = 1 * weights[idx]

    # Additional features: index from the end of the previous features
    features[-4] = dto.salary_expectation
    features[-3] = hash(dto.city) % 1000  # Example of a simple hash encoding for city
    features[-2] = dto.required_experience_years
    features[-1] = dto.publications_required

    return features


additional_skills = ["web_development", "statistical_analysis", "deep_learning", "cloud_computing", "big_data"]
additional_certificates = [
    "Certified Python Programmer",
    "Advanced Machine Learning Specialist",
    "Big Data Analyst Certification",
    "AWS Certified Solutions Architect",
    "Certified Ethical Hacker",
    "Google Cloud Professional Data Engineer"
]


def generate_candidates(base_list, num_variants=1):
    new_candidates = []
    for base in base_list:
        for _ in range(num_variants):
            # Randomly add new skills with random proficiency levels
            skills_update = {skill: random.randint(1, 10) for skill in
                             random.sample(additional_skills, random.randint(0, 3))}
            skills_update.update(base["skills"])

            # Randomly add new certificates, ensuring no duplicates
            new_certs = random.sample(additional_certificates, random.randint(0, 2))
            combined_certs = list(set(base["certificates"] + new_certs))

            new_candidate = {
                "name": base["name"],
                "salary_expectation": base["salary_expectation"] + random.randint(-10000, 10000),
                "city": random.choice(["Київ", "Одеса", "Львів", "Харків", "Дніпро"]),
                "experience_years": base["experience_years"] + random.choice([-1, 0, 1]),
                "skills": {k: max(1, v + random.choice([-1, 0, 1])) for k, v in skills_update.items()},
                "languages": base["languages"],
                "publications": base["publications"] + random.choice([-1, 0, 1]),
                "certificates": combined_certs
            }
            new_candidates.append(new_candidate)
    return new_candidates


def scale_experience(experience):
    scaler = MinMaxScaler(feature_range=(0, 10))  # Scale to a similar range as skills
    return scaler.fit_transform(np.array(experience).reshape(-1, 1)).flatten()


def normalize_vector(vector):
    norm = np.linalg.norm(vector)
    if norm == 0:
        return vector
    return vector / norm


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