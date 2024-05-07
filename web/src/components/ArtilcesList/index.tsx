import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router";

import {
  VacancyCard,
  Container,
  AuthorName,
  VacancyDescription,
  VacancyTitle,
  VacancyMetadata,
} from "./styles";

import { VacancyDTO, getVacancies } from "../../api/vacancy";
import { getFormatedDate } from "../../utils/date";

const VacancyList = () => {
  const navigate = useNavigate();
  const [vacancies, setVacancies] = useState<VacancyDTO[] | null>(null);

  useEffect(() => {
    async function getResponse() {
      const result = await getVacancies();

      if (result) {
        setVacancies(result as VacancyDTO[]);
      }
    }

    getResponse();
  }, []);

  return (
    <Container>
      {vacancies &&
        vacancies.map(art => {
          return (
            <VacancyCard
              onClick={() => navigate(`/vacancies/${art.id}`)}
              key={`Vacancy-${art.id}`}
            >
              <VacancyMetadata>0 - відгукнулось</VacancyMetadata>
              <VacancyTitle>{art.jobTitle}</VacancyTitle>
              <VacancyDescription>
                Lorem Ipsum is simply dummy text of the printing and typesetting
                industry. Lorem Ipsum has been the industry's standard dummy
                text ever since the 1500s, when an unknown printer took a galley
                of type and scrambled it to make a type specimen book. It has
                survived not only five centuries, but also the leap into
                electronic typesetting, remaining essentially unchanged. It was
                popularised in the 1960s with the release of Letraset sheets
                containing Lorem Ipsum passages, and more recently with desktop
                publishing software like Aldus PageMaker including versions of
                Lorem Ipsum.
              </VacancyDescription>
            </VacancyCard>
          );
        })}
    </Container>
  );
};

export default VacancyList;
