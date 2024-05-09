import { CircularProgress } from '@mui/material';
import React, { useState } from 'react'
import { useFetch } from '../../../customHooks/useFetch';
import { SimpleConfigurationItem } from '../../../models/SimpleConfigurationItem';
import ConfigurationItemCard from '../item-cards/ConfigurationItemCard';
import { ConfigurationStepWrapperBox, LoadingWrapperBox } from './ConfigurationStepStyle';

type Props = {
    defaultActive: SimpleConfigurationItem,
    imgDirectory: string,
    imgPrefix: string,
    url: string,
    onChangeStepItem: (item: SimpleConfigurationItem) => void;
}

function ConfigurationSimpleStep(props: Props) {

    const { defaultActive, imgDirectory, imgPrefix, url, onChangeStepItem } = props;

    const [active, setActive] = useState<SimpleConfigurationItem>(defaultActive);

    const { fetchData, loading } = useFetch<SimpleConfigurationItem[]>(url)

    return (
        (loading) ?
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
                            setActive(item)
                            onChangeStepItem(item)
                        }}
                        isActive={item.code === active.code}
                    />
                )}
            </ConfigurationStepWrapperBox>
    )
}

export default ConfigurationSimpleStep;
