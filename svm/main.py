from sklearn.cluster import KMeans
from sklearn.preprocessing import StandardScaler
from sklearn.svm import SVC

from data import *
from utils import *

job_dto = dict_to_dto(job_data)
candidates_dto = [dict_to_dto(candidate_data) for candidate_data in candidates]

# Convert DTOs to features
job_features = dto_to_features(job_dto, job_dto)  # Self comparison to keep function signature consistent
candidate_features = np.array([dto_to_features(candidate, job_dto) for candidate in candidates_dto])

scaler = StandardScaler()
candidates_scaled = scaler.fit_transform(candidate_features)

# Кластеризація K-Means
kmeans = KMeans(n_clusters=3, n_init=10,random_state=42)
kmeans.fit(candidates_scaled)
cluster_labels = kmeans.labels_

# Отримання центроїдів кластерів
centroids = kmeans.cluster_centers_

# Використання SVM для аналізу кластерів
svm = SVC(kernel='linear')
svm.fit(candidates_scaled, cluster_labels)

support_vectors = svm.support_vectors_

ideal_candidate = scaler.transform([job_features])[0]
distances = np.linalg.norm(centroids - ideal_candidate, axis=1)
closest_cluster = np.argmin(distances)
print("Cluster closest to the ideal candidate:", closest_cluster)

# Find which candidates are in the closest cluster
candidates_in_closest_cluster = np.where(cluster_labels == closest_cluster)[0]
print("Candidates in the closest cluster:", candidates_in_closest_cluster)

# Optionally, print details of these candidates
for idx in candidates_in_closest_cluster:
    print("Candidate", idx + 1, "details:", candidate_features[idx])
