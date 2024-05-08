import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

import {
  getMostSuitableCandidates,
  SelectionResultDTO,
} from "../../api/vacancy";

import {
  CandidatesContainer,
  CandidateItem,
  CandidateInfo,
  ProgressBar,
  Progress,
  CandidatesHeader,
} from "./styles";

interface CandidatesListProps {
  vacancyId: string;
}

const CanidatesList = ({ vacancyId }: CandidatesListProps) => {
  const navigate = useNavigate();
  const [candidates, setCandidates] = useState<SelectionResultDTO[] | null>(
    null
  );

  useEffect(() => {
    async function getResponse() {
      const result = await getMostSuitableCandidates(vacancyId);

      if (result) {
        setCandidates(result as SelectionResultDTO[]);
      }
    }

    getResponse();
  }, []);

  const handleCandidateClick = (candidateId: any) => {
    navigate(`/candidates/${candidateId}`);
  };

  return (
    <CandidatesContainer>
      <CandidatesHeader>Most suitable candidates: </CandidatesHeader>
      {candidates &&
        candidates.map(c => (
          <CandidateItem
            key={c.candidate}
            onClick={() => handleCandidateClick(c.candidate)}
          >
            <CandidateInfo>
              {c.name} - {c.yearsOfExperience} years
            </CandidateInfo>
            <ProgressBar>
              <Progress width={Math.round(c.matchScore)}>
                {Math.round(c.matchScore)}%
              </Progress>
            </ProgressBar>
          </CandidateItem>
        ))}
    </CandidatesContainer>
  );
};

export default CanidatesList;
