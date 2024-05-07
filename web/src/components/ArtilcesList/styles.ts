import styled from "styled-components";

const Container = styled.div`
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  gap: 20px;
`;

const VacancyCard = styled.div`
  background: white;
  border-radius: 8px;
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  gap: 10px;
  padding: 16px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  width: 400px;
  max-height: 200px;
  transition: box-shadow 0.3s ease, transform 0.3s ease;

  &:hover {
    cursor: pointer;
    box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15);
    transform: translateY(-2px);
  }
`;

const VacancyTitle = styled.h1`
  font-size: 24px;
  color: #333;
  margin: 0;
`;

const AuthorName = styled.h2`
  font-size: 16px;
  font-weight: normal;
  color: #666;
  margin: 8px 0;
`;

const VacancyMetadata = styled.div`
  display: flex;
  align-items: center;
  justify-content: start;
  font-size: 14px;
  color: #999;
`;

const VacancyDescription = styled.div`
  font-size: 14px;
  color: #666;
  height: auto;
  max-height: 4.2em;
  overflow: hidden;
  display: -webkit-box;
  -webkit-box-orient: vertical;
  -webkit-line-clamp: 3;
`;

export {
  Container,
  VacancyCard,
  VacancyTitle,
  AuthorName,
  VacancyMetadata,
  VacancyDescription,
};
