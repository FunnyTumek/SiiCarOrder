import { CardActionArea, CardMedia, Typography } from "@mui/material";
import {
  ConfigurationItemContentStack,
  ConfigurationItemExtendedContentBox,
  ConfigurationItemImageBox,
  ConfigurationItemWrapperCard,
} from "./ConfigurationItemStyles";

type ConfigurationItemExtendedCardProps = {
  importantInfo: string[];
  imgDirectory: string;
  imgName: string;
  additionalInfo: string[];
  onClickHandler: () => void;
  isActive: boolean;
};

const ConfigurationItemExtendedCard = (
  props: ConfigurationItemExtendedCardProps
) => (
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
            alt="image"
          />
        </ConfigurationItemImageBox>
        <ConfigurationItemExtendedContentBox>
          {props.importantInfo.map((info, idx) => (
            <Typography
              key={idx}
              variant="h4"
              fontWeight="bold"
              color="text.secondary"
              textAlign="left"
              marginTop="40px"
              borderBottom="1px solid grey"
            >
              {info[0].toUpperCase() + info.slice(1)}
            </Typography>
          ))}
          {props.additionalInfo.map((item, idx) => (
            <Typography key={idx} textAlign="left" color="text.secondary">
              {item[0].toUpperCase() + item.slice(1)}
            </Typography>
          ))}
        </ConfigurationItemExtendedContentBox>
      </ConfigurationItemContentStack>
    </CardActionArea>
  </ConfigurationItemWrapperCard>
);

export default ConfigurationItemExtendedCard;
