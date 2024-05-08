import {
  LocationDTO,
  SkillDTO,
  CertificateDTO,
  LanguageSkillDTO,
  PublicationDTO,
  EducationDTO,
} from "../vacancy";

export interface CandidateDTO {
  id: string;
  fullName: string;
  description: string;
  salaryExpectation: number;
  experience: number;
  location: LocationDTO;
  candidateSkills: SkillDTO[];
  candidateCertificates: CertificateDTO[];
  candidateLanguageSkills: LanguageSkillDTO[];
  candidatePublications: PublicationDTO[];
  education: EducationDTO;
}
