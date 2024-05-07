import React, { PropsWithChildren } from "react";
import styled from "styled-components";

export const Pill = ({
  children,
}: PropsWithChildren<PillProps>): JSX.Element => {
  return <PillStyle>{children}</PillStyle>;
};

interface PillProps {}

const PillStyle = styled.span`
  display: inline-flex;
  align-items: center;
  justify-content: center;
  padding: 8px 12px;
  border-radius: 4px; // Slightly less rounded for a tech look
  margin-right: 10px;
  margin-bottom: 10px;
  font-size: 12px; // Smaller font for tech aesthetics
  font-family: "Segoe UI", "Arial", sans-serif;
  text-transform: uppercase; // Makes the text uppercase for a uniform tech appearance
  color: #ffffff;
  background-color: #333333; // Dark background for a sleek look
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.25); // Subtle shadow for a 3D effect

  &:hover {
    transform: translateY(-2px); // Slight raise effect on hover
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15); // Enhanced shadow on hover
  }
`;
