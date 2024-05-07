const BASE_URL = process.env.REACT_APP_BASE_URL || "";

// Articles
const VACANCIES = `${BASE_URL}/vacancies`;
const VACANCY = (id: string) => `${BASE_URL}/vacancies/${id}`;
const MOSTSUITABLECANDIDATES = `${BASE_URL}/get-candidates`;

export { VACANCIES, VACANCY, MOSTSUITABLECANDIDATES };
