import { useEffect, useRef, useState, forwardRef } from 'react';
import { Alert, Container, Stack } from '@mui/material';
import { Grid } from '@mui/material';
import CategorySelector from './CategorySelector';
import CarCard from './CarCard';
import SettingsOutlinedIcon from '@mui/icons-material/SettingsOutlined';
import ConfigurationModal from '../modals/ConfigurationModal';
import FilterType from '../../models/FilterType';
import { useFetch } from '../../customHooks/useFetch';
import { BoxContainer, StyledButton, StyledButtonText, StyledStack, StyledTitle } from './CarSelectorStyles';
import { ConfigurationModel } from '../../models/ConfigurationModel';


type Props = {
  url: string
}

export default function CarSelector(props: Props) {
  const { url } = props
  const [data, setData] = useState<ConfigurationModel[]>()
  const [activeFilter, setActivefilter] = useState<FilterType>("All")

  const { fetchData } = useFetch<ConfigurationModel[]>(url)

  useEffect(() => {
    setData(fetchData);
  }, [fetchData])

  useEffect(() => {
    setData(data);
  }, [activeFilter, data])

  const changeActivefilter = (filter: FilterType) => {
    setActivefilter(filter)
  }

  const handleCreateCarClick = () => {
    window.location.href = "/configurator";
  }   

  return (
    <BoxContainer>
      <Container>
        <StyledStack>
          <StyledTitle> Build your SII car </StyledTitle>
          <Stack direction='row'>
            <ConfigurationModal />
            <StyledButton variant="contained" onClick={handleCreateCarClick} endIcon={<SettingsOutlinedIcon />}>
              <StyledButtonText> Create SII car </StyledButtonText>
            </StyledButton>
          </Stack>
        </StyledStack>

        <CategorySelector changeFilter={changeActivefilter} />
      </Container>
      <Grid container>
        {
          activeFilter !== "All" ?
            data?.filter(x => x.class.name === activeFilter).map((item, idx) => (
              <CarCard key={idx} model={item} />)) :
            data?.map((item, idx) => (
              <CarCard key={idx} model={item} />)) //TODO: change filtering by name to filtering by code
        }
      </Grid>
    </BoxContainer >
  )
}