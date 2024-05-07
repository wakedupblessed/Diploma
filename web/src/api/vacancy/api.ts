import { defaultFetch, protectedFetch } from "../common/http";
import { processResponse } from "../common/utils";

import { VacancyDTO, SelectionResultDTO } from "./interfaces";

import { MOSTSUITABLECANDIDATES, VACANCIES, VACANCY } from "./urls";

export const getVacancies = async (): Promise<
  VacancyDTO[] | null | boolean
> => {
  const response = await defaultFetch<VacancyDTO[]>(VACANCIES);
  return processResponse(response);
};

export const getVacancyById = async (
  id: string
): Promise<VacancyDTO | null | boolean> => {
  const response = await defaultFetch<VacancyDTO>(`${VACANCY(id)}`);
  return processResponse(response);
};

export const getMostSuitableCandidates = async (
  id: string
): Promise<SelectionResultDTO[] | null | boolean> => {
  const response = await defaultFetch<SelectionResultDTO[]>(
    MOSTSUITABLECANDIDATES,
    {
      method: "post",
      data: { vacancyId: id },
    }
  );
  return processResponse(response);
};

// export const postVacancy = async (
//   Vacancy: CreateVacancyCommand,
//   token: string
// ): Promise<string | null | boolean> => {
//   const response = await protectedFetch<string>(VacancyS, token, {
//     method: "post",
//     data: Vacancy,
//   });
//   return processResponse(response);
// };

// export const updateVacancy = async (
//   Vacancy: UpdateVacancyCommand,
//   token: string
// ): Promise<boolean | null | boolean> => {
//   const response = await protectedFetch<boolean>(VacancyS, token, {
//     method: "put",
//     data: Vacancy,
//   });
//   return processResponse(response);
// };

// export const deleteVacancy = async (
//   id: string,
//   token: string
// ): Promise<boolean | null | boolean> => {
//   const response = await protectedFetch<boolean>(`${Vacancy(id)}`, token, {
//     method: "delete",
//   });
//   return processResponse(response);
// };
