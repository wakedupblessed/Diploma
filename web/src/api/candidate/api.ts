import { defaultFetch, protectedFetch } from "../common/http";
import { processResponse } from "../common/utils";

import { CandidateDTO } from "./interfaces";

import { CANDIDATE } from "./urls";

export const getCandidateById = async (
  id: string
): Promise<CandidateDTO | null | boolean> => {
  const response = await defaultFetch<CandidateDTO>(`${CANDIDATE(id)}`);
  return processResponse(response);
};
