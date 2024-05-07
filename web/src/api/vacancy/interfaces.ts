export interface VacancyDTO {
  id: string;
  jobTitle: string;
  description: string;
  salaryExpectation: number;
  experienceYears: number;
  location: LocationDTO;
  vacancySkills: SkillDTO[];
  vacancyCertificates: CertificateDTO[];
  vacancyLanguageSkills: LanguageSkillDTO[];
  vacancyPublications: PublicationDTO[];
  education: EducationDTO;
}

export interface LocationDTO {
  name: string;
}

export interface SkillDTO {
  name: string;
  level: number;
}

export interface CertificateDTO {
  name: string;
  companyName: string;
}

export interface EducationDTO {
  name: string;
  level: EducationLevel;
}

export interface LanguageSkillDTO {
  name: string;
  level: LanguageLevel;
}

export interface PublicationDTO {
  title: string;
  journalName: string;
  doi: string;
  yearOfPublication: number;
}

export interface SelectionResultDTO {
  matchScore: number;
  candidate: string;
  name: string;
  yearsOfExperience: number;
}

export enum LanguageLevel {
  A1,
  A2,
  B1,
  B2,
  C1,
  C2,
}

export enum EducationLevel {
  BachelorsDegree,
  MastersDegree,
  Doctorate,
}
