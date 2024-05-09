import { styled, Grid } from '@mui/material';
import { HEADER_HEIGHT } from '../constant/viewConstant/viewCostant';

type Props = {
  children?: JSX.Element;
}
const ContentWrapper = styled(Grid)`
margin: 0 auto;
width:100%;
padding-top:${HEADER_HEIGHT};
height: 100%;
overflow-y:auto;
alighitems:center;
justify-content: center;
`
export default function Content(props: Props) {
  return (
    <ContentWrapper container>
      {props.children}
    </ContentWrapper >
  )
}