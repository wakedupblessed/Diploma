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

import { CandidateDTO, getCandidateById } from "../../api/candidate";

import { StyledButton } from "../../components/GlobalStyles";
import { LanguageSkills, Skills } from "../../components/features/Skills";
import Certificates from "../../components/features/Certificates";
import Education from "../../components/features/Educations";
import Publications from "../../components/features/Publications";

const CandidateDetail = () => {
  const [candidate, setVacancy] = useState<CandidateDTO | null>(null);

  const { candidateId } = useParams();

  const getResponse = useCallback(async () => {
    if (candidateId) {
      const result = await getCandidateById(candidateId);
      console.log(result);
      setVacancy(result as CandidateDTO);
    }
  }, [candidateId]);

  useEffect(() => {
    getResponse();
  }, [getResponse]);

  return (
    <PageContainer>
      {candidate && (
        <>
          <Header>
            <HeaderTitle>{candidate.fullName}</HeaderTitle>
          </Header>
          <PageContent>
            <VacancyContainer>
              <Title>{candidate.fullName}</Title>
              <VacancyLocation>{candidate.location.name}</VacancyLocation>
              <SalaryAndExperienceContainer>
                <Salary>${candidate.salaryExpectation}</Salary>
                <Experience>
                  Experience: {candidate.experience} years
                </Experience>
              </SalaryAndExperienceContainer>
              <Text>{candidate.description}</Text>
              <Features>
                {candidate.candidateSkills &&
                  candidate.candidateSkills.length > 0 && (
                    <SectionContainer
                      title="Skills: "
                      element={<Skills data={candidate.candidateSkills} />}
                    />
                  )}
                {candidate.candidateLanguageSkills &&
                  candidate.candidateLanguageSkills.length > 0 && (
                    <SectionContainer
                      title="Language skills:"
                      element={
                        <LanguageSkills
                          data={candidate.candidateLanguageSkills}
                        />
                      }
                    />
                  )}
                {candidate.candidateCertificates &&
                  candidate.candidateCertificates.length > 0 && (
                    <SectionContainer
                      title="Certificates:"
                      element={
                        <Certificates data={candidate.candidateCertificates} />
                      }
                    />
                  )}
                {candidate.education && (
                  <SectionContainer
                    title="Education:"
                    element={<Education data={candidate.education} />}
                  />
                )}
                {candidate.candidatePublications && (
                  <SectionContainer
                    title="Publications:"
                    element={
                      <Publications data={candidate.candidatePublications} />
                    }
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

export default CandidateDetail;
