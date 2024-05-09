import { Box, Card, Stack, styled } from "@mui/material";
import { DEFAULT_CONTENT_MARGIN } from "../../../constant/viewConstant/viewCostant";

export const ConfigurationItemWrapperCard = styled(Card)(
  ({ theme }) => `
    margin: 0 auto;
    margin-top: ${DEFAULT_CONTENT_MARGIN};
    height: 200px;
  `
);

export const ConfigurationItemContentStack = styled(Stack)(
  ({ theme }) => `
    flex-direction: row;
    width: 605px;
  `
);

export const ConfigurationItemImageBox = styled(Box)(
  ({ theme }) => `
    width: 350px;
    display: flex;
    align-items: center;
  `
);

export const ConfigurationItemContentBox = styled(Box)(
  ({ theme }) => `
    width: 250px;
    display: flex;
    flex-direction: row;
    align-items: center
  `
);

export const ConfigurationItemExtendedContentBox = styled(Box)(
  ({ theme }) => `
    width: 250px;
    display: flex;
    flex-direction: column;
    align-items: flex-start;
  `
);
