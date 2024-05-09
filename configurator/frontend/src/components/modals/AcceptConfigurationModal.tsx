import * as React from "react";
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import Button from '@mui/material/Button';
import { useNavigate } from 'react-router-dom';
import { SubDetalesText } from '../indexPage/CarCardStyle';

const styleChild = {
    position: "absolute" as "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    width: 200,
    bgcolor: "background.paper",
    textAlign: "center",
    boxShadow: 24,
    p: 3,
}

export default function AcceptConfigurationModal() {

    const navigate = useNavigate();
    const [open, setOpen] = React.useState(false);
    const handleOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
        navigate('/');
        window.location.reload();
    };

    return (
        <React.Fragment>
            <div onClick={handleOpen}>
                Order configuration
            </div>
            <Modal
                hideBackdrop
                open={open}
                onClose={handleClose}
                aria-labelledby="child-modal-title"
                aria-describedby="child-modal-description"
            >
                <Box sx={{ ...styleChild }}>
                    <Box>
                        <SubDetalesText>
                            Your order has been sent to the dealer
                        </SubDetalesText>
                    </Box>
                    <Button onClick={handleClose}>
                        Close
                    </Button>
                </Box>
            </Modal>
        </React.Fragment>
    );
}