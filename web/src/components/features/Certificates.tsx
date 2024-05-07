import React from "react";
import styled from "styled-components";
import { CommonProps } from "./Skills";
import { CertificateDTO } from "../../api/vacancy";

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

const Certificates = ({ data }: CommonProps) => {
  const options = data as CertificateDTO[];
  return (
    <CertificatesContainer>
      {options.map((certificate, index) => (
        <CertificateItem key={index}>
          <Title>{certificate.name},</Title>
          <Issuer>{certificate.companyName}</Issuer>
        </CertificateItem>
      ))}
    </CertificatesContainer>
  );
};

export default Certificates;
