const BASE_URL = process.env.REACT_APP_BASE_URL || "";

// Articles
const CANDIDATE = (id: string) => `${BASE_URL}/candidates/${id}`;

export { CANDIDATE };
