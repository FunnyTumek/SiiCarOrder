import * as React from "react";
import Step from "@mui/material/Step";
import StepLabel from "@mui/material/StepLabel";
import Typography from "@mui/material/Typography";
import ConfigurationSimpleStep from "../steps/ConfigurationSimpleStep";
import { useReducer } from "react";
import EngineModel from "../../../models/EngineModel";
import GearboxModel from "../../../models/GearboxModel";
import ConfigurationEngineStep from "../steps/ConfigurationEngineStep";
import ConfigurationGearboxStep from "../steps/ConfigurationGearboxStep";
import ConfigurationAdditionalEquipmentStep from "../steps/ConfigurationAdditionalEquipmentStep";
import ArrowBackIosIcon from "@mui/icons-material/ArrowBackIos";
import ArrowForwardIosIcon from "@mui/icons-material/ArrowForwardIos";
import configurationReducer from "./StepperStateReducer";
import ACTIONS from "./StepperActions";
import {
  MainWrapper,
  StyledStepper,
  StepWrapper,
  SummaryButtonWrapper,
  StyledButton,
  ConfiguratorButtonText,
} from "./StepperStyles";
import { ConfigurationModel } from "../../../models/ConfigurationModel";
import { SimpleConfigurationItem } from "../../../models/SimpleConfigurationItem";
import { AdditionalEquipmentItem } from "../../../models/AdditionalEquipmentItem";
import SendConfigurationModal from "../../modals/SendConfigurationModal";
import { Steps } from "./Steps";
import StepperSummary from "./Summary/StepperSummary";
import SaveConfigurationModal from "../../modals/SaveConfigurationModal";

const steps = Object.values(Steps);

const initialState: ConfigurationModel = {
  brand: {
    code: "BC01",
    name: "Sii",
  },
  model: {
    code: "MC01",
    name: "Model S",
  },
  equipmentVersion: {
    code: "EV01",
    name: "Basic",
  },
  class: {
    code: "CC01",
    name: "City",
  },
  engine: {
    code: "EC01",
    name: "1.0 TSI",
    type: "Petrol",
    capacity: 998,
    power: 75,
  },
  gearbox: {
    code: "GC01",
    type: "manual",
    gearsCount: 5,
  },
  color: {
    code: "CO01",
    name: "black",
  },
  interior: {
    code: "IC01",
    name: "black leather",
  },
  additionalEquipment: [
    {
      code: "AE01",
      name: "comfort seat package",
    },
  ],
  price: 90000,
};

const HorizontalLinearStepper = () => {
  const [state, dispatch] = useReducer(configurationReducer, initialState);
  const [activeStep, setActiveStep] = React.useState(0);
  const [skipped, setSkipped] = React.useState(new Set<number>());

  const handleChangeCarClass = (carClass: SimpleConfigurationItem) => {
    dispatch({ type: ACTIONS.ADD_CAR_CLASS, payload: carClass });
  };

  const handleChangeCarModel = (carModel: SimpleConfigurationItem) => {
    dispatch({ type: ACTIONS.ADD_CAR_MODEL, payload: carModel });
  };

  const handleChangeCarEquipmentVersion = (
    carEquipmentVersion: SimpleConfigurationItem
  ) => {
    dispatch({
      type: ACTIONS.ADD_CAR_EQUIPMENT_VERSION,
      payload: carEquipmentVersion,
    });
  };

  const handleChangeCarColor = (carColor: SimpleConfigurationItem) => {
    dispatch({ type: ACTIONS.ADD_CAR_COLOR, payload: carColor });
  };

  const handleChangeCarInterior = (carInterior: SimpleConfigurationItem) => {
    dispatch({ type: ACTIONS.ADD_CAR_INTERIOR, payload: carInterior });
  };

  const handleChangeCarEngine = (carEngine: EngineModel) => {
    dispatch({ type: ACTIONS.ADD_CAR_ENGINE, payload: carEngine });
  };

  const handleChangeCarGearbox = (carGearbox: GearboxModel) => {
    dispatch({ type: ACTIONS.ADD_CAR_GEARBOX, payload: carGearbox });
  };

  const handleChangeCarAdditionalEquipment = (
    carAdditionalEquipmentSelect: AdditionalEquipmentItem
  ) => {
    dispatch({
      type: ACTIONS.SELECT_CAR_ADDITIONAL_EQUIPMENT,
      payload: carAdditionalEquipmentSelect,
    });
  };

  function getStepContent(step: number) {
    switch (step) {
      case 0:
        return (
          <ConfigurationSimpleStep
            key={step}
            imgDirectory="carModels"
            imgPrefix="car"
            url="/api/configuration/available/classes"
            onChangeStepItem={handleChangeCarClass}
            defaultActive={state.class}
          />
        );
      case 1:
        return (
          <ConfigurationSimpleStep
            key={step}
            imgDirectory="carModels"
            imgPrefix="car"
            url="/api/configuration/available/models"
            onChangeStepItem={handleChangeCarModel}
            defaultActive={state.model}
          />
        );
      case 2:
        return (
          <ConfigurationSimpleStep
            key={step}
            imgDirectory="carModels"
            imgPrefix="car"
            url="/api/configuration/available/equipmentVersions"
            onChangeStepItem={handleChangeCarEquipmentVersion}
            defaultActive={state.equipmentVersion}
          />
        );
      case 3:
        return (
          <ConfigurationSimpleStep
            key={step}
            imgDirectory="carModels"
            imgPrefix="car"
            url="/api/configuration/available/colors"
            onChangeStepItem={handleChangeCarColor}
            defaultActive={state.color}
          />
        );
      case 4:
        return (
          <ConfigurationSimpleStep
            key={step}
            imgDirectory="carModels"
            imgPrefix="car"
            url="/api/configuration/available/interiors"
            onChangeStepItem={handleChangeCarInterior}
            defaultActive={state.interior}
          />
        );
      case 5:
        return (
          <ConfigurationEngineStep
            key={step}
            imgDirectory="carModels"
            imgPrefix="car"
            url="/api/configuration/available/engines"
            onChangeStepItem={handleChangeCarEngine}
            defaultActive={state.engine}
          />
        );
      case 6:
        return (
          <ConfigurationGearboxStep
            key={step}
            imgDirectory="carModels"
            imgPrefix="car"
            url="/api/configuration/available/gearboxes"
            onChangeStepItem={handleChangeCarGearbox}
            defaultActive={state.gearbox}
          />
        );
      case 7:
        return (
          <ConfigurationAdditionalEquipmentStep
            imgDirectory="carModels"
            imgPrefix="car"
            url="/api/configuration/available/additionalEquipment"
            onSelectStepItem={handleChangeCarAdditionalEquipment}
            activeItems={state.additionalEquipment}
          />
        );
      default:
        return "Step with given number does not exist";
    }
  }

  const isStepOptional = (step: number) => {
    return step === 8;
  };

  const isStepSkipped = (step: number) => {
    return skipped.has(step);
  };

  const handleNext = () => {
    let newSkipped = skipped;
    if (isStepSkipped(activeStep)) {
      newSkipped = new Set(newSkipped.values());
      newSkipped.delete(activeStep);
    }

    setActiveStep((prevActiveStep) =>
      prevActiveStep < steps.length ? prevActiveStep + 1 : prevActiveStep
    );
    setSkipped(newSkipped);
  };

  const handleBack = () => {
    setActiveStep((prevActiveStep) =>
      prevActiveStep > 0 ? prevActiveStep - 1 : prevActiveStep
    );
  };

  const handleSkip = () => {
    if (!isStepOptional(activeStep)) {
      throw new Error("You can't skip a step that isn't optional.");
    }

    setActiveStep((prevActiveStep) => prevActiveStep + 1);
    setSkipped((prevSkipped) => {
      const newSkipped = new Set(prevSkipped.values());
      newSkipped.add(activeStep);
      return newSkipped;
    });
  };

  const handleKeyDown = (event: KeyboardEvent): any => {
    switch (event.key) {
      case "ArrowLeft":
        return handleBack();
      case "ArrowRight":
        return handleNext();
    }
  };

  const handleActiveStep = (step: number): void => {
    setActiveStep(step)
  }

  React.useEffect(() => {
    window.addEventListener("keydown", handleKeyDown);

    return () => {
      window.removeEventListener("keydown", handleKeyDown);
    };
  });

  return (
    <MainWrapper>
      <StyledStepper activeStep={activeStep}>
        {steps.map((label, index) => {
          const stepProps: { completed?: boolean } = {};
          const labelProps: {
            optional?: React.ReactNode;
          } = {};
          if (isStepOptional(index)) {
            labelProps.optional = (
              <Typography variant="caption">Optional</Typography>
            );
          }
          if (isStepSkipped(index)) {
            stepProps.completed = false;
          }
          return (
            <Step key={label} {...stepProps}>
              <StepLabel {...labelProps}>{label}</StepLabel>
            </Step>
          );
        })}
      </StyledStepper>
      <>
        {activeStep === steps.length ? (
          <>
            <StepWrapper>
              <StepperSummary
                defaultState={state}
                setActiveStep={handleActiveStep}
                setCarAdditionalEquipment={handleChangeCarAdditionalEquipment}
              />
            </StepWrapper>
            <SummaryButtonWrapper>
              <SendConfigurationModal configuration={state} />
              <SaveConfigurationModal configuration={state} />
            </SummaryButtonWrapper>
          </>
        ) : (
          <>
            <StepWrapper>{getStepContent(activeStep)}</StepWrapper>

            <SummaryButtonWrapper>
              <StyledButton
                variant="outlined"
                disabled={activeStep === 0}
                onClick={handleBack}
                endIcon={<ArrowBackIosIcon />}
              >
                <ConfiguratorButtonText> Back </ConfiguratorButtonText>
              </StyledButton>
              {isStepOptional(activeStep) && (
                <StyledButton
                  variant="outlined"
                  onClick={handleSkip}
                  sx={{ mr: 1 }}
                >
                  <ConfiguratorButtonText> Skip </ConfiguratorButtonText>
                </StyledButton>
              )}
              <StyledButton
                variant="outlined"
                onClick={handleNext}
                endIcon={<ArrowForwardIosIcon />}
              >
                <ConfiguratorButtonText>
                  {activeStep === steps.length - 1 ? "Finish" : "Next"}
                </ConfiguratorButtonText>
              </StyledButton>
            </SummaryButtonWrapper>
          </>
        )}
      </>
    </MainWrapper>
  );
};
export default HorizontalLinearStepper;
