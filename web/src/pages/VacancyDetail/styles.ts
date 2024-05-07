import styled from "styled-components";

const PageContainer = styled.div`
  display: flex;
  flex-direction: column;
  margin: 20px;
`;

const Header = styled.header`
  display: flex;
  justify-content: space-between;
  align-items: center;
`;

const HeaderTitle = styled.p``;

const HeaderActions = styled.div`
  display: flex;
  align-items: center;
  gap: 10px;
`;

const Edited = styled.div`
  font-size: 14px;
  color: grey;
`;

const ActionItem = styled.div``;

const PageContent = styled.div`
  display: grid;
  grid-template-columns: 1fr 4fr 1fr 1fr;
  margin-top: 100px;
`;

const Features = styled.div`
  grid-column: 2;
`;

const Title = styled.h1`
  color: rgb(55, 53, 47);
  font-size: 48px;
  margin-bottom: 20px;
  grid-column: 2;
`;

const Text = styled.div`
  margin: 20px 0px;

  font-weight: 400;
  font-size: 18px;
  font-style: normal;
  background-color: #f7f6f3;
  display: inline;
  text-align: left;
  flex-shrink: 1;

  grid-column: 2;
`;

const VacancyLocation = styled.div`
  font-size: 18px;
  color: #666;
  font-weight: normal;
  margin-top: -10px;

  grid-column: 2;
`;

const SalaryAndExperienceContainer = styled.div`
  display: flex;
  gap: 20px;
  margin-top: 10px;

  grid-column: 2;
`;

const Salary = styled.div`
  font-size: 16px;
  color: rgb(55, 53, 47);
  font-weight: bold;
`;

const Experience = styled.div`
  font-size: 16px;
  color: rgb(55, 53, 47);
  font-weight: bold;
`;

const CandidatesContainer = styled.div`
  border: 1px solid #ccc;
  grid-column: 3 / -1;
`;

export {
  Title,
  PageContainer,
  Header,
  HeaderTitle,
  HeaderActions,
  ActionItem,
  PageContent,
  Text,
  Edited,
  Features,
  VacancyLocation,
  SalaryAndExperienceContainer,
  Salary,
  Experience,
  CandidatesContainer,
};
