import { Box, Button, styled, Typography } from "@mui/material"
import { DEFAULT_CONTENT_MARGIN } from "../../constant/viewConstant/viewCostant"

export const BoxContainer = styled(Box)(
    ({ theme }) => `
  width:1280px;
  background-color:${theme.palette.grey[50]};
  padding:60px;
  box-shadow: ${theme.shadows[24]};
`
)
export const Container = styled(Box)(({ theme }) => ({
    display: 'flex',
    flexDirection: "column",
    [theme.breakpoints.down("md")]: { flexDirection: "column", alignItems: 'center' },
})
)
export const StyledTitle = styled(Typography)(({ theme }) => ({
    fontSize: `${theme.typography.h3.fontSize}`,
    fontWeight: 'bold',
    marginLeft: DEFAULT_CONTENT_MARGIN,
    flexGrow: 1,
    color: `${theme.palette.primary}`,
    [theme.breakpoints.down("md")]: { margin: '0 auto' }
})
)
export const StyledStack = styled(Box)(({ theme }) => ({
    display: 'flex',
    [theme.breakpoints.up("md")]: { flexDirection: 'row' },
    [theme.breakpoints.down("md")]: { flexDirection: 'column' }
})
)

export const StyledButton = styled(Button)(
    ({ theme }) => `
color:${theme.palette.action};
border-radius:52px;
height:48px;
min-width:120px;
margin-right: ${DEFAULT_CONTENT_MARGIN};
`)

export const StyledButtonText = styled(Typography)(
    ({ theme }) => `
font-size:${theme.typography.subtitle1.fontSize};
color:${theme.palette.primary.contrastText};
line-height:18px;
`)