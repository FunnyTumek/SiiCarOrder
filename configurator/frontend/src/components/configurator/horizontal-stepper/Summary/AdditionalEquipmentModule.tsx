import RemoveCircleIcon from '@mui/icons-material/RemoveCircle';
import { IconButton, Stack } from '@mui/material';
import { AdditionalEquipmentItem } from '../../../../models/AdditionalEquipmentItem';
import { ConfigurationModel } from '../../../../models/ConfigurationModel';
import AddIcon from '@mui/icons-material/Add';
import { AdditionalEquipment, SummaryText, AdditionalEquipmentBox, Item, AdditionalEquipmentDeleteButton } from './SummaryStyle/AdditionalEquipmentModule';

type Props = {
    state: ConfigurationModel,
    deleteBtn: (item: AdditionalEquipmentItem) => void,
    setActiveStep: (step: number) => void,
    children: React.ReactNode
}

const AdditionalEquipmentModule = (props: Props) => {
    const { state, deleteBtn, setActiveStep } = props
    return (
        <AdditionalEquipment container>
            <SummaryText>Additional equipment:</SummaryText>
            <Stack sx={{ flexDirection: 'row', flexWrap: 'wrap', minWidth: '100%', alignItems: 'center' }}>
                {state.additionalEquipment.map((item, idx) => {
                    return (
                        <AdditionalEquipmentBox key={idx}>
                            <Item>{item.name.toUpperCase()}
                                <AdditionalEquipmentDeleteButton onClick={() => deleteBtn(item)}>
                                    <RemoveCircleIcon />
                                </AdditionalEquipmentDeleteButton>
                            </Item>
                        </AdditionalEquipmentBox>
                    );
                })}
                <IconButton onClick={() => setActiveStep(7)}><AddIcon /></IconButton>
            </Stack>
        </AdditionalEquipment>
    )
}

export default AdditionalEquipmentModule
