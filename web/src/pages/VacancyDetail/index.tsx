import React, { useEffect, useState, useCallback } from "react";

import { useNavigate, useParams } from "react-router-dom";
import { toast } from "react-toastify";

import {
  Title,
  PageContainer,
  Header,
  HeaderTitle,
  PageContent,
  Text,
  Edited,
  VacancyLocation,
  Features,
  SalaryAndExperienceContainer,
  Salary,
  Experience,
  CandidatesContainer,
  VacancyContainer,
} from "./styles";

import SectionContainer from "../../components/common/Section";

import { VacancyDTO, getVacancyById } from "../../api/vacancy";

import { StyledButton } from "../../components/GlobalStyles";
import { LanguageSkills, Skills } from "../../components/features/Skills";
import Certificates from "../../components/features/Certificates";
import Education from "../../components/features/Educations";

import CanidatesList from "../../components/CandidatesList";

const VacancyDetail = () => {
  const [vacancy, setVacancy] = useState<VacancyDTO | null>(null);

  const { vacancyId } = useParams();

  const getResponse = useCallback(async () => {
    if (vacancyId) {
      const result = await getVacancyById(vacancyId);
      console.log(result);
      setVacancy(result as VacancyDTO);
    }
  }, [vacancyId]);

  useEffect(() => {
    getResponse();
  }, [getResponse]);

  return (
    <PageContainer>
      {vacancy && (
        <>
          <Header>
            <HeaderTitle>{vacancy.jobTitle}</HeaderTitle>
          </Header>
          <PageContent>
            <CandidatesContainer>
              <CanidatesList vacancyId={vacancy.id} />
            </CandidatesContainer>
            <VacancyContainer>
              <Title>{vacancy.jobTitle}</Title>
              <VacancyLocation>{vacancy.location.name}</VacancyLocation>
              <SalaryAndExperienceContainer>
                <Salary>${vacancy.salaryExpectation}</Salary>
                <Experience>
                  Experience required: {vacancy.experienceYears} years
                </Experience>
              </SalaryAndExperienceContainer>
              <Text>{vacancy.description}</Text>
              <Features>
                {vacancy.vacancySkills && vacancy.vacancySkills.length > 0 && (
                  <SectionContainer
                    title="Required skills"
                    element={<Skills data={vacancy.vacancySkills} />}
                  />
                )}
                {vacancy.vacancyLanguageSkills &&
                  vacancy.vacancyLanguageSkills.length > 0 && (
                    <SectionContainer
                      title="Required language skills"
                      element={
                        <LanguageSkills data={vacancy.vacancyLanguageSkills} />
                      }
                    />
                  )}
                {vacancy.vacancyCertificates &&
                  vacancy.vacancyCertificates.length > 0 && (
                    <SectionContainer
                      title="Required certificates"
                      element={
                        <Certificates data={vacancy.vacancyCertificates} />
                      }
                    />
                  )}
                {vacancy.education && (
                  <SectionContainer
                    title="Required education"
                    element={<Education data={vacancy.education} />}
                  />
                )}
              </Features>
            </VacancyContainer>
          </PageContent>
        </>
      )}
    </PageContainer>
  );
};

export default VacancyDetail;
