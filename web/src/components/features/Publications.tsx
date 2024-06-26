import React from "react";
import styled from "styled-components";
import { CommonProps } from "./Skills";
import { PublicationDTO } from "../../api/vacancy";

const CertificatesContainer = styled.div``;

const CertificateItem = styled.div`
  padding: 10px 0;
`;

const Title = styled.h3`
  font-size: 16px;
  margin: 0;
  color: #333;
`;

const Issuer = styled.span`
  font-size: 14px;
  color: #666;
`;

const Doi = styled.div`
  font-size: 14px;
  margin: 0;
  color: #333;
  font-weight: bold;
`;

const Publications = ({ data }: CommonProps) => {
  const options = data as PublicationDTO[];
  return (
    <CertificatesContainer>
      {options.map((publication, index) => (
        <CertificateItem key={index}>
          <Title>{publication.title},</Title>
          <Doi>Doi - {publication.doi},</Doi>
          <Issuer>Journal - {publication.journalName}</Issuer>
        </CertificateItem>
      ))}
    </CertificatesContainer>
  );
};

export default Publications;
