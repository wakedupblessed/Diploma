import styled from "styled-components";

import { getLanguageLevelLabel } from "../../utils/utils";

import {
  SkillDTO,
  LanguageSkillDTO,
  CertificateDTO,
  PublicationDTO,
  EducationDTO,
} from "../../api/vacancy";
import { Pill } from "../common/Pilll";

export interface CommonProps {
  data:
    | SkillDTO[]
    | LanguageSkillDTO[]
    | CertificateDTO[]
    | PublicationDTO[]
    | EducationDTO;
  // consultantId?: string | null
  // consultant?: ConsultantInterface | null
}

const Skills = ({ data }: CommonProps) => {
  const options = data as SkillDTO[];

  return (
    <SkillsContainer>
      {options.map(skill => (
        <Pill key={skill.name}>
          {skill.name} - {skill.level}
        </Pill>
      ))}
    </SkillsContainer>
  );
};

const LanguageSkills = ({ data }: CommonProps) => {
  const options = data as LanguageSkillDTO[];

  return (
    <SkillsContainer>
      {options.length > 0 && (
        <>
          {" "}
          {options.map(skill => (
            <Pill key={skill.name}>
              {skill.name} - {getLanguageLevelLabel(skill.level)}
            </Pill>
          ))}
        </>
      )}
    </SkillsContainer>
  );
};

const SkillsContainer = styled.div``;

export { Skills, LanguageSkills };
