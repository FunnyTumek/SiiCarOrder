import * as React from "react";
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import { Stack, TextField } from "@mui/material";
import { CustomerData } from "../../models/CustomerData";
import { ConfiguratorButtonText, StyledButton } from "../configurator/horizontal-stepper/StepperStyles";
import { ConfigurationModel } from "../../models/ConfigurationModel";
import axios from "axios";
import { IConfigurationModelDto } from "../../models/IConfigurationModelDto";
import { BASEURL } from "../../constant/connection/ConnectionConstants";
import AcceptConfigurationModal from "../modals/AcceptConfigurationModal";

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

type Props = {
  configuration: ConfigurationModel;
};

const defaultValues: CustomerData = {
  firstName: "",
  lastName: "",
  email: "",
  phone: "",
};

const mapToConfigurationModelDto = (
  configurationModel: ConfigurationModel
): IConfigurationModelDto => {
  const ConfigurationModelDto: IConfigurationModelDto = {
    BrandCode: "",
    ClassCode: "",
    ColorCode: "",
    EngineCode: "",
    EquipmentVersionCode: "",
    GearboxCode: "",
    InteriorCode: "",
    ModelCode: "",
    AdditionalEquipmentCodes: [],
  };

  ConfigurationModelDto.BrandCode = configurationModel.brand.code;
  ConfigurationModelDto.ClassCode = configurationModel.class.code;
  ConfigurationModelDto.ColorCode = configurationModel.color.code;
  ConfigurationModelDto.EngineCode = configurationModel.engine.code;
  ConfigurationModelDto.EquipmentVersionCode =
    configurationModel.equipmentVersion.code;
  ConfigurationModelDto.GearboxCode = configurationModel.gearbox.code;
  ConfigurationModelDto.InteriorCode = configurationModel.interior.code;
  ConfigurationModelDto.ModelCode = configurationModel.model.code;

  for (let i = 0; i < configurationModel.additionalEquipment.length; i++) {
    ConfigurationModelDto.AdditionalEquipmentCodes.push(
      configurationModel.additionalEquipment[i].code
    );
  }
  return ConfigurationModelDto;
};

export default function SendConfigurationModal(props: Props) {

  const [open, setOpen] = React.useState(false);
  const handleShow = () => setOpen(true);
  const handlePop = () => setOpen(false);
  const [formValues, setFormValues] = React.useState(defaultValues);

  const handleInputChange = (e: any) => {
    const { name, value } = e.target;
    setFormValues({
      ...formValues,
      [name]: value,
    });
  };

  const handleSend = (e: any) => {
    e.preventDefault();
    const pack = {
      configuration: mapToConfigurationModelDto(props.configuration),
      customer: formValues,
    };
    axios.post(`${BASEURL}/api/configuration/order`, pack).then((response) => {
    });
  };

  return (
    <div>
      <StyledButton variant="outlined" onClick={handleShow}>
        <ConfiguratorButtonText> Order configuration</ConfiguratorButtonText>
      </StyledButton>
      <Modal
        open={open}
        onClose={handlePop}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <form onSubmit={handleSend}>
          <Box sx={style}>
            <Stack direction="column" spacing={2}>
              <TextField
                required
                id="firstName"
                name="firstName"
                label="First Name"
                type="text"
                onChange={handleInputChange}
                value={formValues.firstName}
                helperText="Please enter your first name"
              />
              <TextField
                required
                id="lastName"
                name="lastName"
                label="Last Name"
                type="text"
                onChange={handleInputChange}
                value={formValues.lastName}
                helperText="Please enter your last name"
              />
              <TextField
                required
                id="email"
                name="email"
                label="Email"
                type="email"
                onChange={handleInputChange}
                value={formValues.email}
                helperText="Please enter your email"
              />
              <TextField
                required
                id="phone"
                name="phone"
                label="Phone number"
                type="string"
                onChange={handleInputChange}
                value={formValues.phone}
                helperText="Please enter your phone number"
              />

              <StyledButton type="submit" variant="outlined">
                <ConfiguratorButtonText>
                  <AcceptConfigurationModal />
                </ConfiguratorButtonText>
              </StyledButton>
            </Stack>
          </Box>
        </form>
      </Modal>
    </div>
  );
}
