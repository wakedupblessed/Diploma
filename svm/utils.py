import numpy as np
from geopy import Nominatim
from geopy.distance import geodesic
import stanza

# stanza.download('uk')

from data import *


def dict_to_dto(data):
    return SvmDTO(
        description=data['description'],
        salary_expectation=data["salary_expectation"],
        city=data["city"],
        required_experience_years=data["experience_years"],
        required_skills=data["skills"],
        language_requirements=data["languages"],
        publications_required=data["publications"],
        certificates=data["certificates"],
        education=data.get("education", None)
    )


nlp_uk = stanza.Pipeline(lang='uk', processors='tokenize,mwt,pos,lemma')


soft_skills_keywords_uk = {
    "communication": ["спілкування", "усний", "письмовий", "слухання", "виразний", "аргументація", "переконливий"],
    "teamwork": ["команда", "співпраця", "кооперація", "група", "партнерство", "взаємодія"],
    "leadership": ["лідер", "управління", "директор", "начальник", "організатор", "ініціативність"],
    "problem-solving": ["вирішення", "рішення", "знаходження", "інновація", "креативність", "аналітика"]
}

soft_skills_cache = {}


def extract_soft_skills(description):
    doc = nlp_uk(description.lower())
    skill_scores = {skill: 0 for skill in soft_skills_keywords_uk}

    # Increment score if a keyword is found in the description
    for sentence in doc.sentences:
        for token in sentence.words:
            for skill, keywords in soft_skills_keywords_uk.items():
                if token.lemma in keywords:
                    skill_scores[skill] += 1

    return skill_scores


def get_soft_skills(description, soft_skills_index, weights):

    cache_key = hash(description)

    if cache_key in soft_skills_cache:
        return soft_skills_cache[cache_key]
    else:

        soft_skills_scores = extract_soft_skills(description)
        weighted_scores = {}
        for skill, score in soft_skills_scores.items():
            if skill in soft_skills_index:
                idx = soft_skills_index[skill]
                weighted_scores[idx] = score * weights[idx]

        soft_skills_cache[cache_key] = weighted_scores
        return weighted_scores


def build_feature_index(candidates, job):
    all_skills = set()
    all_languages = set()
    all_certificates = set()
    all_soft_skills = set(soft_skills_keywords_uk.keys())

    # Collect skills, languages, and certificates from candidates
    for candidate in candidates:
        all_skills.update(candidate.required_skills.keys())
        all_languages.update(candidate.language_requirements.keys())
        all_certificates.update(candidate.certificates)

    # Also add job description skills, languages, and certificates
    all_skills.update(job.required_skills.keys())
    all_languages.update(job.language_requirements.keys())
    all_certificates.update(job.certificates)

    all_education_qualifications = {
                                       f"{candidate.education['level']}-{candidate.education['name']}"
                                       for candidate in candidates if candidate.education
                                   } | {
                                       f"{job.education['level']}-{job.education['name']}"
                                       if job.education else None
                                   }
    all_education_qualifications.discard(None)

    # Create index maps for dynamic features
    skill_index = {skill: i for i, skill in enumerate(sorted(all_skills))}
    language_index = {lang: len(skill_index) + i for i, lang in enumerate(sorted(all_languages))}
    certificate_index = {cert: len(skill_index) + len(language_index) + i for i, cert in enumerate(sorted(all_certificates))}
    soft_skills_index = {soft_skill: len(skill_index) + len(language_index) + len(certificate_index) + i for
                         i, soft_skill in enumerate(sorted(all_soft_skills))}
    education_index = {
        qual: len(skill_index) + len(language_index) + len(certificate_index) + i
        for i, qual in enumerate(sorted(all_education_qualifications))
    }

    return skill_index, language_index, certificate_index, soft_skills_index, education_index


def dto_to_features(dto, job_dto, weights, skill_index, language_index, certificate_index, soft_skills_index, education_index):
    total_features = len(skill_index) + len(language_index) + len(certificate_index) + len(soft_skills_index) + len(
        education_index) + 5
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

    if dto.education:
        education_qual = f"{dto.education['level']}-{dto.education['name']}"
        if education_qual in education_index:
            idx = education_index[education_qual]
            features[idx] = 1 * weights[idx]

    soft_skills_features = get_soft_skills(dto.description, soft_skills_index, weights)
    for idx, value in soft_skills_features.items():
        features[idx] = value

    distance = 0

    if dto.city.lower() != "remote" and job_dto.city.lower() != "remote":
        city1_location = get_geocode(dto.city)
        city2_location = get_geocode(job_dto.city)

        if city1_location and city2_location:
            city1_lat, city1_lon = city1_location[0], city1_location[1]
            city2_lat, city2_lon = city2_location[0], city2_location[1]

            distance = geodesic((city1_lat, city1_lon), (city2_lat, city2_lon)).kilometers
        else:
            distance = 0

    elif dto.city.lower() == "remote" or job_dto.city.lower() == "remote":
        distance = 0

    # Apply weights to features
    features[-5] = distance * weights[-5]
    features[-4] = dto.salary_expectation * weights[-4]
    features[-3] = hash(dto.city) % 1000 * weights[-3]
    features[-2] = dto.required_experience_years * weights[-2]
    features[-1] = dto.publications_required * weights[-1]

    return features


geo_cache = {}
geolocator = Nominatim(user_agent="my_application")


def get_geocode(city):
    # Use city name in lowercase as the cache key
    city_lower = city.lower()
    if city_lower in geo_cache:
        return geo_cache[city_lower]
    else:
        location = geolocator.geocode(city)
        if location:
            geo_cache[city_lower] = (location.latitude, location.longitude)
        else:
            geo_cache[city_lower] = -1  # Cache the negative result to avoid re-querying
        return (location.latitude, location.longitude)