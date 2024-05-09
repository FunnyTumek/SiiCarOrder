import * as React from "react";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";
import { styled } from "@mui/system";
import FileUploadOutlinedIcon from "@mui/icons-material/FileUploadOutlined";
import { Stack, TextField } from "@mui/material";
import { DEFAULT_CONTENT_MARGIN } from "../../constant/viewConstant/viewCostant";

const style = {
  position: "absolute" as "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 400,
  bgcolor: "background.paper",
  boxShadow: 24,
  p: 4,
};

const StyledButton = styled(Button)(
  ({ theme }) => `
color:${theme.palette.action};
border-radius:52px;
height:48px;
min-width:120px;
margin-right: ${DEFAULT_CONTENT_MARGIN};
`
);

const ButtonText = styled(Typography)(
  ({ theme }) => `
  color: ${theme.palette.secondary};
  text-transform: uppercase;
  margin-top:4px;
  line-height:18px;
  `
);

export default function ConfigurationModal() {
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  return (
    <div>
      <StyledButton
        variant="contained"
        onClick={handleOpen}
        endIcon={<FileUploadOutlinedIcon />}
      >
        <ButtonText variant="subtitle1">Load Configuration</ButtonText>
      </StyledButton>
      <Modal open={open} onClose={handleClose}>
        <Box sx={style}>
          <Stack direction="column" spacing={2}>
            <TextField
              helperText="Please enter your configuration ID"
              id="configurationID"
              label="configurationID"
            />
            <StyledButton aria-label="authorization">Continue</StyledButton>
          </Stack>
        </Box>
      </Modal>
    </div>
  );
}
