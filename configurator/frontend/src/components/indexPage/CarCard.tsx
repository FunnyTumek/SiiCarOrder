import { Box, CardMedia, Stack } from '@mui/material';
import carImg from '../../images/car-img.png';
import { ConfigurationModel } from '../../models/ConfigurationModel';
import { ButtonWrapper, DetalesBox, DetalesSubTitle, DetalesTitle, ImgBox, Price, PriceBox, StyledButton, StyledCard, SubDetalesBox, SubDetalesText } from './CarCardStyle';

type Props = {
  model: ConfigurationModel;
}

export default function CarCard(props: Props) {

  const { model } = props;

  return (
    <Box>
      <StyledCard square={true}>
        <Stack direction='row'>
          <ImgBox>
            <CardMedia component="img" height="180" image={carImg} alt={'Img'} />
          </ImgBox>
          <DetalesBox>
            <DetalesTitle> {model.model.name} </DetalesTitle>
            <DetalesSubTitle> {model.class.name} </DetalesSubTitle>
            <SubDetalesBox>
              <SubDetalesText> {model.engine.name} </SubDetalesText>
              <SubDetalesText> {model.engine.type} </SubDetalesText>
              <SubDetalesText> {model.gearbox.type} </SubDetalesText>
            </SubDetalesBox>
          </DetalesBox>
        </Stack >

        <Stack direction='row' >
          <PriceBox>
            <Price>$ {model.price}</Price>
          </PriceBox>
          <ButtonWrapper>
            <StyledButton> Enquire now </StyledButton>
            <StyledButton> Compare </StyledButton>
          </ButtonWrapper>
        </Stack>
      </StyledCard >
    </Box >
  )
}