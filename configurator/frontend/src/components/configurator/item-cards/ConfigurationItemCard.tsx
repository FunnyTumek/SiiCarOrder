import { CardActionArea, CardMedia, Typography } from "@mui/material";
import {
  ConfigurationItemWrapperCard,
  ConfigurationItemContentStack,
  ConfigurationItemContentBox,
  ConfigurationItemImageBox,
} from "./ConfigurationItemStyles";

type ConfigurationItemCardProps = {
  label: string;
  imgDirectory: string;
  imgName: string;
  onClickHandler: () => void;
  isActive: boolean;
};

const ConfigurationItemCard = (props: ConfigurationItemCardProps) => (
  <ConfigurationItemWrapperCard
    sx={{
      backgroundColor: `${props.isActive ? "action.selected" : "action"}`,
    }}
  >
    <CardActionArea onClick={() => props.onClickHandler()}>
      <ConfigurationItemContentStack>
        <ConfigurationItemImageBox>
          <CardMedia
            component="img"
            image={require(`../../../images/${props.imgDirectory}/${props.imgName}`)}
            alt={props.label}
          />
        </ConfigurationItemImageBox>
        <ConfigurationItemContentBox>
          <Typography
            variant="h4"
            fontWeight="bold"
            color="text.secondary"
            textAlign="left"
          >
            {props.label[0].toUpperCase() + props.label.slice(1)}
          </Typography>
        </ConfigurationItemContentBox>
      </ConfigurationItemContentStack>
    </CardActionArea>
  </ConfigurationItemWrapperCard>
);

export default ConfigurationItemCard;
