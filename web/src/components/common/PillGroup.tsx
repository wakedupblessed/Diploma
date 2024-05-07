import React, { PropsWithChildren } from "react";
import styled from "styled-components";

export const PillGroupStyle = styled.div`
  margin: 0;
  display: inline-block;
`;

export const PillGroup = ({
  children,
}: PropsWithChildren<unknown>): JSX.Element => {
  return <PillGroupStyle>{children}</PillGroupStyle>;
};
