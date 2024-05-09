import { styled, ToggleButton, ToggleButtonGroup, Typography } from '@mui/material';
import { categories } from '../../models/Categories';
import FilterType from '../../models/FilterType';

const StyledToggleButton = styled(ToggleButton)`
size:small;
border:none;
`
const ToggleButtonText = styled(Typography)(
  ({ theme }) => `
  font-size:${theme.typography.h6.fontSize};
`)

type PropsType =
  {
    changeFilter: (filter: FilterType) => void;
  }

export default function CategorySelector(props: PropsType) {
  const handleClick = (
    event: React.MouseEvent<HTMLElement>,
    category: FilterType,
  ) => {
    props.changeFilter(category);
  }
  const avaliablecategory: FilterType[] = [...categories]

  return (
    <>
      <ToggleButtonGroup defaultValue={"All"}>
        {
          avaliablecategory.map((category, idx) => (
            <StyledToggleButton onClick={handleClick} key={idx} value={category}>
              <ToggleButtonText>
                {category}
              </ToggleButtonText>
            </StyledToggleButton>
          ))
        }
      </ToggleButtonGroup>
    </>
  )
}