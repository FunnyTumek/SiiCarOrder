import { Box } from "@mui/material";
import { styled } from "@mui/material/styles";

export const LoadingWrapperBox = styled(Box)(
  ({ theme }) => `
    display: flex;
    justifyContent: center
  `
);

export const ConfigurationStepWrapperBox = styled(Box)(
  ({ theme }) => `
    display: flex;
    flex-wrap: wrap;
    justify-content: space-between;
    background-color: ${theme.palette.grey[50]};
    padding-bottom: 2px;
  `
);
