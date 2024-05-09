import { Box, Button, Stepper, styled, Typography } from "@mui/material"
import { DEFAULT_CONTENT_MARGIN } from "../../../constant/viewConstant/viewCostant"

export const StyledButton = styled(Button)(
    ({ theme }) => `

  color:${theme.palette.action};
  border-radius:52px;
  height:60px;
  margin:0 ${DEFAULT_CONTENT_MARGIN} 0 ${DEFAULT_CONTENT_MARGIN};
  `)

export const MainWrapper = styled(Box)(
    ({ theme }) => `
  display: flex;
  flex-direction:column;
  width:1280px;
  height:100%;
  padding:0px 60px 0 60px;
  background-color:${theme.palette.grey[50]};
  box-shadow:${theme.shadows[24]};
  `)

export const StyledStepper = styled(Stepper)`
    margin-top:48px;
    `

export const StepWrapper = styled(Box)(
    ({ theme }) => `
  margin-top:36px;
  overflow-y:auto;
  flex-grow:1;
  flex-wrap:wrap;
  align-content:flex-start;
 `)

export const SummaryButtonWrapper = styled(Box)`
  display:flex;
  flex-direction:row;
  margin:24px auto 24px auto;
    `

export const ConfiguratorButtonText = styled(Typography)(
    ({ theme }) => `
  font-size:${theme.typography.h6.fontSize};
  color:${theme.palette.text.secondary};
  font-weight:bold;
    `)