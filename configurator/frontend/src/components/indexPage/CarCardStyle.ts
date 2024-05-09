import { Box, Button, ButtonGroup, Card, styled, Typography } from "@mui/material"
import { DEFAULT_CONTENT_MARGIN } from "../../constant/viewConstant/viewCostant"

export const StyledCard = styled(Card)`
display:flex;
flex-direction:column;
margin: ${DEFAULT_CONTENT_MARGIN};
width:605px;
height:224px;
:hover {
  box-shadow: rgb(0,0,0,35%) 0px 10px 2rem;
};
`
export const StyledButton = styled(Button)(
    ({ theme }) => `
width: 140px;
height: 40px;
border-radius: 24px;
line-height: 16px;
`)
export const ImgBox = styled(Box)`
height: 160px;
padding: 0;
`
export const DetalesBox = styled(Box)`
width: 290px;
height: 140px;
padding: 10px;
`
export const SubDetalesBox = styled(Box)(
    ({ theme }) => `
border-top: 1px solid ${theme.palette.grey[400]};
padding-top:5px;
`
)
export const PriceBox = styled(Box)`
width: 305px;
height: 60px;
padding: 10px;
`
export const SubDetalesText = styled(Typography)(
    ({ theme }) => `
  font-size:${theme.typography.subtitle1.fontSize};
`)

export const DetalesTitle = styled(Typography)(
    ({ theme }) => `
  font-size:${theme.typography.h5.fontSize};
  font-weight:bold;
`)
export const DetalesSubTitle = styled(Typography)(
    ({ theme }) => `
  font-size:${theme.typography.h6.fontSize};
`)

export const Price = styled(Typography)(
    ({ theme }) => `
  font-size:${theme.typography.h5.fontSize};
  font-weight:bold;
  text-align:center;
`)
export const ButtonWrapper = styled(ButtonGroup)`
  width:300px;
  height:60px;
  padding:10px;
`