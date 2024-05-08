import styled from "styled-components";

const CandidatesContainer = styled.div`
  display: flex;
  flex-direction: column;
  font-family: "Segoe UI", "Arial", sans-serif;
`;

const CandidateItem = styled.div`
  padding: 10px;
  margin: 5px 0;
  cursor: pointer;
  border: 1px solid #ccc;
  border-radius: 5px;
  transition: background-color 0.3s;
  font-size: 16px; // Set this to match your project's text size

  &:hover {
    background-color: #f4f4f4;
  }
`;

const CandidatesHeader = styled.div`
  margin-bottom: 5px;
  font-size: 20px;
  color: rgb(55, 53, 47);
  font-weight: bold;
`;

const CandidateInfo = styled.div`
  margin-bottom: 5px;
  font-size: 16px;
  color: rgb(55, 53, 47);
  font-weight: bold;
`;

const ProgressBar = styled.div`
  background-color: #e0e0e0;
  border-radius: 5px;
  overflow: hidden;
`;

const Progress = styled.div<{ width: number }>`
  height: 20px;
  background-color: #333333; // Dark background for a sleek look
  color: white;
  display: flex;
  align-items: center;
  justify-content: center;
  font-weight: bold;
  border-radius: 5px;
  width: ${props => props.width}%;
`;

export {
  CandidatesContainer,
  CandidateItem,
  CandidateInfo,
  ProgressBar,
  Progress,
  CandidatesHeader,
};
