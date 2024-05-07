import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

import {
  getMostSuitableCandidates,
  SelectionResultDTO,
} from "../../api/vacancy";

import { CandidatesContainer } from "./styles";

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

  return (
    <CandidatesContainer>
      {candidates &&
        candidates.map(c => (
          <>
            {c.name} | {c.matchScore} | {c.yearsOfExperience}
          </>
        ))}
    </CandidatesContainer>
  );
};

export default CanidatesList;
