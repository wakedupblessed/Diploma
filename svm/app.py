from flask import Flask, request, jsonify
import numpy as np
import joblib
from data import SvmDTO
from utils import dict_to_dto, dto_to_features, build_feature_index

app = Flask(__name__)

scaler = joblib.load('scaler.pkl')
kmeans = joblib.load('kmeans.pkl')
svm = joblib.load('svm.pkl')
best_weights = joblib.load('weights.pkl')


@app.route('/predict', methods=['POST'])
def predict():
    try:
        # Get candidate and vacancy data from the request
        data = request.json

        candidates = data.get('candidates', [])
        vacancy = data.get('vacancy', {})

        job_dto = process_vacancy_data(vacancy)
        processed_candidates = process_candidate_data(candidates)

        skill_index, language_index, certificate_index = build_feature_index(processed_candidates, job_dto)

        job_features = dto_to_features(job_dto, job_dto, best_weights, skill_index, language_index, certificate_index)
        candidate_features = np.array([dto_to_features(candidate, job_dto, best_weights, skill_index, language_index, certificate_index)
                                       for candidate in processed_candidates])

        # Scale the features of all candidates
        candidates_scaled = scaler.transform(candidate_features)

        # Predict the cluster for each candidate
        candidate_clusters = kmeans.predict(candidates_scaled)

        # Identify the ideal candidate's cluster
        ideal_candidate_scaled = scaler.transform([job_features])[0]
        centroids = kmeans.cluster_centers_
        distances = np.linalg.norm(centroids - ideal_candidate_scaled, axis=1)
        closest_cluster = np.argmin(distances)

        # Filter candidates in the closest cluster
        candidates_in_closest_cluster = np.where(candidate_clusters == closest_cluster)[0]
        candidates_in_cluster = [processed_candidates[i] for i in candidates_in_closest_cluster]

        # Prepare the response
        response = {
            "closest_cluster": int(closest_cluster),
            "candidates_in_closest_cluster": candidates_in_cluster
        }
        return jsonify(response)
    except Exception as e:
        return jsonify({"error": str(e)})


def process_vacancy_data(vacancy):
    required_skills = {skill['name']: skill['level'] for skill in vacancy.get('Skills', [])}
    language_requirements = {lang['name']: lang['proficiency'] for lang in vacancy.get('LanguageSkills', [])}

    job_dto = SvmDTO(
        salary_expectation=vacancy.get('SalaryExpectation', 0),
        city=vacancy.get('City', ''),
        required_experience_years=vacancy.get('ExperienceYears', 0),
        required_skills=required_skills,
        language_requirements=language_requirements,
        publications_required=vacancy.get('Publications', 0),
        certificates=vacancy.get('Certificates', [])
    )

    return job_dto


def process_candidate_data(candidates):
    processed_candidates = []
    for candidate_data in candidates:
        required_skills = {skill['name']: skill['level'] for skill in candidate_data.get('Skills', [])}
        language_requirements = {lang['name']: lang['proficiency'] for lang in candidate_data.get('LanguageSkills', [])}
        candidate_dto = SvmDTO(
            salary_expectation=candidate_data.get('SalaryExpectation', 0),
            city=candidate_data.get('City', ''),
            required_experience_years=candidate_data.get('ExperienceYears', 0),
            required_skills=candidate_data.get('Skills', {}),
            language_requirements=candidate_data.get('LanguageSkills', {}),
            publications_required=candidate_data.get('Publications', 0),
            certificates=candidate_data.get('Certificates', [])
        )
        processed_candidates.append(candidate_dto)

    return processed_candidates


if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0')


