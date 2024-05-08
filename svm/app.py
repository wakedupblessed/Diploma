import joblib
import numpy as np
from flask import Flask, request, jsonify
from sklearn.impute import SimpleImputer
from data import SvmDTO
from utils import dto_to_features, build_feature_index

app = Flask(__name__)


kmeans = joblib.load('kmeans.pkl')
scaler = joblib.load('scaler.pkl')
svm = joblib.load('svm.pkl')
best_weights = joblib.load('weights.pkl')


@app.route('/predict', methods=['POST'])
def predict():
    try:
        data = request.json

        candidates = data.get('candidates', [])
        vacancy = data.get('vacancy', {})

        job_dto = process_vacancy_data(vacancy)
        processed_candidates = process_candidate_data(candidates)
        candidate_ids, dtos = zip(*processed_candidates)
        skill_index, language_index, certificate_index, soft_skills_index, education_index = build_feature_index(dtos, job_dto)

        job_features = dto_to_features(job_dto, job_dto, best_weights, skill_index, language_index, certificate_index, soft_skills_index, education_index)
        candidate_features = np.array(
            [dto_to_features(candidate, job_dto, best_weights, skill_index, language_index, certificate_index, soft_skills_index, education_index)
             for candidate in dtos])

        median_imputer = SimpleImputer(strategy='constant', fill_value=0)
        final_imputed = median_imputer.fit_transform(candidate_features)

        candidates_scaled = scaler.fit_transform(final_imputed)

        kmeans.fit(candidates_scaled)

        job_features_reshaped = job_features.reshape(1, -1)
        ideal_imputed = median_imputer.transform(job_features_reshaped)
        ideal_scaled = scaler.transform(ideal_imputed)

        cluster_labels = kmeans.labels_
        svm.fit(candidates_scaled, cluster_labels)

        svm_predicted = svm.predict(candidates_scaled)

        # Analyze results
        centroids = kmeans.cluster_centers_
        ideal_candidate_scaled = scaler.transform(ideal_scaled)
        distances = np.linalg.norm(centroids - ideal_candidate_scaled, axis=1)
        closest_cluster = np.argmin(distances)

        candidate_distances = np.linalg.norm(candidates_scaled - ideal_candidate_scaled, axis=1)
        max_distance = candidate_distances.max()

        candidates_in_closest_cluster = [
            {
                "candidate": candidate_ids[i],
                "MatchScore": 100 * candidate_distances[i] / max_distance
            }
            for i in range(len(candidate_ids)) if svm_predicted[i] == closest_cluster
        ]

        return jsonify(candidates_in_closest_cluster)
    except Exception as e:
        return jsonify({"error": str(e)})


def process_vacancy_data(vacancy):
    required_skills = {skill['SkillName']: skill['Level'] for skill in vacancy.get('Skills', [])}
    language_requirements = {lang['Language']: lang['Proficiency'] for lang in vacancy.get('LanguageSkills', [])}
    education_info = None
    if 'Education' in vacancy and vacancy['Education']:
        education_info = {
            "Name": vacancy['Education'].get('Name', ''),
            "Level": vacancy['Education'].get('Level', '')
        }

    job_dto = SvmDTO(
        description=vacancy.get('Description', ''),
        salary_expectation=vacancy.get('SalaryExpectation', 0),
        city=vacancy.get('City', ''),
        required_experience_years=vacancy.get('ExperienceYears', 0),
        required_skills=required_skills,
        language_requirements=language_requirements,
        publications_required=vacancy.get('Publications', 0),
        certificates=vacancy.get('Certificates', []),
        education=education_info
    )

    return job_dto


def process_candidate_data(candidates):
    processed_candidates = []
    for candidate_data in candidates:
        required_skills = {skill['SkillName']: skill['Level'] for skill in candidate_data.get('Skills', [])}
        language_requirements = {lang['Language']: lang['Proficiency'] for lang in
                                 candidate_data.get('LanguageSkills', [])}

        education_info = None
        if 'Education' in candidate_data and candidate_data['Education']:
            education_info = {
                "name": candidate_data['Education'].get('Name', ''),
                "level": candidate_data['Education']['Level']
            }

        candidate_dto = SvmDTO(
            description=candidate_data.get('Description', ''),
            salary_expectation=candidate_data.get('SalaryExpectation', 0),
            city=candidate_data.get('City', ''),
            required_experience_years=candidate_data.get('ExperienceYears', 0),
            required_skills=required_skills,
            language_requirements=language_requirements,
            publications_required=candidate_data.get('Publications', 0),
            certificates=candidate_data.get('Certificates', []),
            education=education_info
        )

        candidate_id = candidate_data.get('Id', None)
        processed_candidates.append((candidate_id, candidate_dto))

    return processed_candidates


if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0')
