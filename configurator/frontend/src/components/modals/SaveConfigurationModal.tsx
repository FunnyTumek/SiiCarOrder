import * as React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Modal from '@mui/material/Modal';
import { styled } from '@mui/system';
import { Stack, TextField } from '@mui/material';
import { ConfiguratorButtonText } from '../configurator/horizontal-stepper/StepperStyles';
import { DEFAULT_CONTENT_MARGIN } from '../../constant/viewConstant/viewCostant';
import { ConfigurationModel } from '../../models/ConfigurationModel';
import axios from 'axios';
import { BASEURL } from '../../constant/connection/ConnectionConstants';

const style = {
    position: 'absolute' as 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    boxShadow: 24,
    p: 4,
};

export const StyledButton = styled(Button)(
    ({ theme }) => `

  color:${theme.palette.action};
  border-radius:52px;
  height:60px;
  margin:0 ${DEFAULT_CONTENT_MARGIN} 0 ${DEFAULT_CONTENT_MARGIN};
  `);

type Props = {
    configuration: ConfigurationModel;
};
type UserEmail = {
    email: string;
}

const defaultValues: UserEmail = {
    email: "",
};

export default function SaveConfigurationModal(props: Props) {
    const [open, setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);
    const [formValues, setFormValues] = React.useState(defaultValues);

    const handleInputChange = (e: any) => {
        const { email, value } = e.target;
        setFormValues({
            ...formValues,
            [email]: value,
        });
    };

    const handleSend = (e: any) => {
        e.preventDefault();
        console.log(props.configuration)
        axios.post(`${BASEURL}/api/configuration`, props.configuration).then((response) => {
            console.log(response);
        });
    };

    return (
        <div>
            <StyledButton variant="outlined" onClick={handleOpen}>
                <ConfiguratorButtonText>
                    Save configuration
                </ConfiguratorButtonText>
            </StyledButton>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <form onSubmit={handleSend}>
                    <Box sx={style}>
                        <Stack direction='column' spacing={2}>
                            <TextField
                                id="email"
                                name="Email"
                                label="Email"
                                type="text"
                                onChange={handleInputChange}
                                value={formValues.email}
                                helperText="Please enter your e-mail address"
                            />
                            <StyledButton type="submit" variant="outlined">Save</StyledButton>
                        </Stack>
                    </Box>
                </form>
            </Modal>
        </div>
    )
}