import { AppBar, Box, Stack, styled, Typography } from "@mui/material"
import { DEFAULT_CONTENT_MARGIN } from "../constant/viewConstant/viewCostant"

export const MainWrapper = styled(Stack)`
  flex-direction:row;
  max-width:1280px;
  margin:0 auto;
  flex-grow:1;
`
export const ToolbarTitle = styled(Typography)(
    ({ theme }) => `
  font-size:${theme.typography.h5.fontSize};
  color:${theme.palette.primary.contrastText};
  margin-left: ${DEFAULT_CONTENT_MARGIN};
  margin-top:6px;
  font-weight:bold;
`)
export const HeaderWrapper = styled(Box)`
  position:absolute;
  flex-grow:fixed;
  height:64px;`

export const StyledAppBar = styled(AppBar)(
    ({ theme }) => `
  color:${theme.palette.primary};
  position:fixed;
  `)