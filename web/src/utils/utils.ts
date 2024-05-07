import { EducationLevel, LanguageLevel } from "../api/vacancy";

const getLanguageLevelLabel = (level: LanguageLevel) => {
  const levelLabels: Record<LanguageLevel, string> = {
    [LanguageLevel.A1]: "Beginner",
    [LanguageLevel.A2]: "Elementary",
    [LanguageLevel.B1]: "Intermediate",
    [LanguageLevel.B2]: "Upper Intermediate",
    [LanguageLevel.C1]: "Advanced",
    [LanguageLevel.C2]: "Proficiency",
  };
  return levelLabels[level];
};

const getEducaionLevelLabel = (level: EducationLevel) => {
  const levelLabels: Record<EducationLevel, string> = {
    [EducationLevel.BachelorsDegree]: "Bachelors",
    [EducationLevel.MastersDegree]: "Masters",
    [EducationLevel.Doctorate]: "Doctorate",
  };
  return levelLabels[level];
};

export { getLanguageLevelLabel, getEducaionLevelLabel };
