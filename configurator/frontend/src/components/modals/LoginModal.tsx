import * as React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Modal from '@mui/material/Modal';
import { styled } from '@mui/system';
import { Stack, TextField } from '@mui/material';
import HeaderModalButton, { HeaderButtonIcon } from './HeaderModalButton';

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

const StyledButton = styled(Button)`
  size:large;
  edge:start;
  color:inherit; 
`

export default function LoginModal() {
    const [open, setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);


    return (
        <div>
            <HeaderModalButton handleOpen={handleOpen} icon={HeaderButtonIcon.Account} title={'Account'} />
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <Box sx={style}>
                    <Stack direction='column' spacing={2}>
                        <TextField helperText="Please enter your login" id="login" label="Login" />
                        <TextField helperText="Please enter your password" id="password" label="Password" />
                        <StyledButton aria-label="autorisation">Continue</StyledButton>
                    </Stack>
                </Box>
            </Modal>
        </div>
    )
}