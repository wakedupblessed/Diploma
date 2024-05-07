import React, { ReactNode } from "react";
import styled from "styled-components";

const SectionContainerStyled = styled.div`
  padding: 20px 0;
  border-bottom: 1px solid #ccc;
`;

const Title = styled.h2`
  margin: 0 0 10px 0;
  padding: 0;
  font-size: 16px;
  color: #333;
`;

interface SectionContainerProps {
  title: string;
  element: ReactNode;
}

const SectionContainer = ({ title, element }: SectionContainerProps) => {
  return (
    <SectionContainerStyled>
      <Title>{title}</Title>
      {element}
    </SectionContainerStyled>
  );
};

export default SectionContainer;
