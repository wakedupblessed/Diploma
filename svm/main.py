import random

import joblib
import numpy as np
from deap import base, creator, tools, algorithms
from sklearn.cluster import KMeans
from sklearn.impute import SimpleImputer
from sklearn.preprocessing import StandardScaler
from sklearn.svm import SVC

from data import candidates, job_data
from utils import dict_to_dto, build_feature_index, dto_to_features

candidates_dto = [dict_to_dto(candidate) for candidate in candidates]
job_dto = dict_to_dto(job_data)

skill_index, language_index, certificate_index, soft_skills_index, education_index = build_feature_index(candidates_dto, job_dto)

feature_index = 5 + len(skill_index) + len(language_index) + len(certificate_index) + len(education_index)

# Set up the genetic algorithm
creator.create("FitnessMin", base.Fitness, weights=(-1.0,))
creator.create("Individual", list, fitness=creator.FitnessMin)
toolbox = base.Toolbox()
toolbox.register("attr_float", random.uniform, 0, 2)  # Weights range
toolbox.register("individual", tools.initRepeat, creator.Individual, toolbox.attr_float, n=feature_index)
toolbox.register("population", tools.initRepeat, list, toolbox.individual)

kmeans = KMeans(n_clusters=5, n_init='auto', random_state=42)


def evaluate(individual):
    candidate_features = np.array(
        [dto_to_features(candidate, job_dto, individual, skill_index, language_index, certificate_index, soft_skills_index, education_index) for candidate
         in candidates_dto])
    scaler = StandardScaler()
    candidates_scaled = scaler.fit_transform(candidate_features)

    kmeans.fit(candidates_scaled)
    ideal_features = dto_to_features(job_dto, job_dto, individual, skill_index, language_index, certificate_index, soft_skills_index, education_index)
    ideal_scaled = scaler.transform([ideal_features])

    distances = np.linalg.norm(kmeans.cluster_centers_ - ideal_scaled, axis=1)
    return (np.min(distances),)


toolbox.register("evaluate", evaluate)
toolbox.register("mate", tools.cxTwoPoint)
toolbox.register("mutate", tools.mutGaussian, mu=0, sigma=0.5, indpb=0.1)
toolbox.register("select", tools.selTournament, tournsize=3)


population = toolbox.population(n=50)
result = algorithms.eaSimple(population, toolbox, cxpb=0.5, mutpb=0.2, ngen=50, verbose=True)
best_weights = tools.selBest(population, 1)[0]
print("Best weights found:", best_weights)

joblib.dump(best_weights, 'weights.pkl')

final_candidate_features = np.array(
    [dto_to_features(candidate, job_dto, best_weights, skill_index, language_index, certificate_index, soft_skills_index, education_index) for candidate in candidates_dto])
job_features = np.array(dto_to_features(job_dto, job_dto, best_weights, skill_index, language_index, certificate_index, soft_skills_index, education_index))

median_imputer = SimpleImputer(strategy='median')
final_imputed = median_imputer.fit_transform(final_candidate_features)

scaler = StandardScaler()
final_scaled = scaler.fit_transform(final_imputed)

job_features_reshaped = job_features.reshape(1, -1)
ideal_imputed = median_imputer.transform(job_features_reshaped)
ideal_scaled = scaler.transform(ideal_imputed)

kmeans.fit(final_scaled)

# Classification
svm = SVC(kernel='linear')
cluster_labels = kmeans.labels_
svm.fit(final_scaled, cluster_labels)

joblib.dump(scaler, 'scaler.pkl')
joblib.dump(kmeans, 'kmeans.pkl')
joblib.dump(svm, 'svm.pkl')
joblib.dump(median_imputer, 'median_imputer.pkl')