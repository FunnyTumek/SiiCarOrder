import { CircularProgress } from '@mui/material';
import { useState } from 'react'
import { useFetch } from '../../../customHooks/useFetch';
import { AdditionalEquipmentItem } from '../../../models/AdditionalEquipmentItem';
import ConfigurationItemCard from '../item-cards/ConfigurationItemCard';
import { ConfigurationStepWrapperBox, LoadingWrapperBox } from './ConfigurationStepStyle';

type Props = {
    activeItems: AdditionalEquipmentItem[],
    imgDirectory: string,
    imgPrefix: string,
    url: string
    onSelectStepItem: (item: AdditionalEquipmentItem) => void;
}

function ConfigurationAdditionalEquipmentStep(props: Props) {
    const { activeItems, imgDirectory, imgPrefix, url, onSelectStepItem } = props;

    const [active, setActive] = useState<AdditionalEquipmentItem[]>(activeItems);

    const { fetchData, loading } = useFetch<AdditionalEquipmentItem[]>(url)

    let switchActive = (item: AdditionalEquipmentItem) => {
        if (active.some(x => x.code === item.code)) {
            setActive(active.filter(i => i.code !== item.code))
        } else {
            setActive([...active, item])
        }
    }

    return (
        (loading)
            ?
            <LoadingWrapperBox> <CircularProgress size={50} /> </LoadingWrapperBox>
            :
            <ConfigurationStepWrapperBox>
                {fetchData?.map((item, idx) =>
                    <ConfigurationItemCard
                        key={idx}
                        label={item.name}
                        imgDirectory={(`${imgDirectory}`)}
                        imgName={(`${imgPrefix}-0.png`)}
                        onClickHandler={() => {
                            switchActive(item)
                            onSelectStepItem(item)
                        }}
                        isActive={active.map(i => i.code).includes(item.code)} />
                )}
            </ConfigurationStepWrapperBox>
    )
}

export default ConfigurationAdditionalEquipmentStep

