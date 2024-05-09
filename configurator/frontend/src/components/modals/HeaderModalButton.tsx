import { styled } from '@mui/system';
import { Button, Typography } from '@mui/material';
import WarehouseOutlinedIcon from '@mui/icons-material/WarehouseOutlined';
import AccountCircleOutlinedIcon from '@mui/icons-material/AccountCircleOutlined';


const StyledButton = styled(Button)`
  size:large;
  edge:start;
  color:inherit; 
`
const ButtonText = styled(Typography)(
    ({ theme }) => `
  color: ${theme.palette.secondary};
  text-transform: none;
  margin-top:4px;
  `
)
interface Props {
    handleOpen: () => void;
    icon: HeaderButtonIcon;
    title: string
}
export enum HeaderButtonIcon {
    Garage,
    Account
}
const HeaderModalButton = (props: Props): JSX.Element => {
    const { handleOpen, icon, title } = props
    let iconElement = undefined;
    const iconStyle = { transform: 'scale(1.5)', mr: '4px', color: 'primary.contrastText' }

    switch (icon) {
        case HeaderButtonIcon.Garage:
            iconElement = (<WarehouseOutlinedIcon sx={iconStyle} />)
            break;
        case HeaderButtonIcon.Account:
            iconElement = (<AccountCircleOutlinedIcon sx={iconStyle} />)
            break;
    }
    return (
        <>
            <StyledButton
                aria-label="garage"
                onClick={handleOpen}
                endIcon={iconElement}
            >
                <ButtonText variant='subtitle1'>{title}</ButtonText>
            </StyledButton >
        </>
    )
};
export default HeaderModalButton

