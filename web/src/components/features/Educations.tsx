import React from "react";
import styled from "styled-components";
import { CommonProps } from "./Skills";
import { EducationDTO } from "../../api/vacancy";

import { getEducaionLevelLabel } from "../../utils/utils";

const EducationContainer = styled.div``;

const EducationItem = styled.div`
  padding: 10px 0;
`;

const Title = styled.h3`
  font-size: 16px;
  margin: 0;
  color: #333;
`;

const Level = styled.span`
  font-size: 14px;
  color: #666;
`;

const Education = ({ data }: CommonProps) => {
  const education = data as EducationDTO;
  return (
    <EducationContainer>
      <EducationItem>
        <Title>{education.name},</Title>
        <Level>{getEducaionLevelLabel(education.level)}</Level>
      </EducationItem>
    </EducationContainer>
  );
};

export default Education;
