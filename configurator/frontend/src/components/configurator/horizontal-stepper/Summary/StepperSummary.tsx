import Box from "@mui/material/Box";
import { ConfigurationModel } from "../../../../models/ConfigurationModel";
import { AdditionalEquipmentItem } from "../../../../models/AdditionalEquipmentItem";
import { useState } from "react";
import AdditionalEquipmentModule from "./AdditionalEquipmentModule";
import ConfigurationOptionItem from "./ConfigurationOptionItem";
import { SummaryText } from "./SummaryStyle/AdditionalEquipmentModule";
import { SummaryStack, ConfigurationOptionsAndImgWrapper, ConfigurationOptionWrapper, PriceBox } from "./SummaryStyle/StepperSummaryStyle";


type Props = {
  defaultState: ConfigurationModel;
  setActiveStep: (step: number) => void;
  setCarAdditionalEquipment: (item: AdditionalEquipmentItem) => void
}

const StepperSummary = (props: Props) => {
  const { defaultState, setActiveStep, setCarAdditionalEquipment } = props
  const [state, setState] = useState(defaultState)

  const removeAdditionalEquipmentHandler = (item: AdditionalEquipmentItem): void => {
    setState({ ...state, additionalEquipment: state.additionalEquipment.filter(x => x.code !== item.code) })
    setCarAdditionalEquipment(item)
  }

  return (
    <>
      <SummaryStack >
        <ConfigurationOptionsAndImgWrapper>
          <Box
            component="img"
            width="80%"
            src={require(`../../../../images/carModels/car-0.png`)}
          />
          <ConfigurationOptionWrapper>
            <ConfigurationOptionItem
              setActiveStep={setActiveStep}
              activeStep={1}
              columnName={[state.brand.name]}
              columnContent={[state.model.name]}>
            </ConfigurationOptionItem>

            <ConfigurationOptionItem
              setActiveStep={setActiveStep}
              activeStep={2}
              columnName={["Equipment", "version:"]}
              columnContent={[state.equipmentVersion.name]}>
            </ConfigurationOptionItem>

            <ConfigurationOptionItem
              setActiveStep={setActiveStep}
              activeStep={0}
              columnName={["Car class:"]}
              columnContent={[state.class.name]}>
            </ConfigurationOptionItem>

            <ConfigurationOptionItem
              setActiveStep={setActiveStep}
              activeStep={5}
              columnName={["Engine:", "Type:", "Power:", "Capacity:"]}
              columnContent={[state.engine.name, state.engine.type, `${state.engine.power}`, `${state.engine.capacity}`]}>
            </ConfigurationOptionItem>

            <ConfigurationOptionItem
              setActiveStep={setActiveStep}
              activeStep={6}
              columnName={["Gearbox:", "Gear count:"]}
              columnContent={[state.gearbox.type, `${state.gearbox.gearsCount}`]}>
            </ConfigurationOptionItem>

            <ConfigurationOptionItem
              setActiveStep={setActiveStep}
              activeStep={3}
              columnName={["Color:"]}
              columnContent={[state.color.name,]}>
            </ConfigurationOptionItem>

            <ConfigurationOptionItem
              setActiveStep={setActiveStep}
              activeStep={4}
              columnName={["Interior:"]}
              columnContent={[state.interior.name]}>
            </ConfigurationOptionItem>
          </ConfigurationOptionWrapper>
        </ConfigurationOptionsAndImgWrapper>

        <AdditionalEquipmentModule
          state={state}
          deleteBtn={removeAdditionalEquipmentHandler}
          setActiveStep={setActiveStep}>
        </AdditionalEquipmentModule>

        <PriceBox>
          <SummaryText>Configuration price</SummaryText>
          <SummaryText>{state.price}</SummaryText>
        </PriceBox>
      </SummaryStack>
    </>
  );
}

export default StepperSummary;
