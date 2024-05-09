import React, { useState } from 'react'
import GearboxModel from '../../../models/GearboxModel';
import ConfigurationItemExtendedCard from '../item-cards/ConfigurationItemExtendedCard';
import isEqual from 'lodash.isequal';
import { useFetch } from '../../../customHooks/useFetch';
import { CircularProgress } from '@mui/material';
import { ConfigurationStepWrapperBox, LoadingWrapperBox } from './ConfigurationStepStyle';

type Props = {
    defaultActive: GearboxModel,
    imgDirectory: string,
    imgPrefix: string,
    url: string,
    onChangeStepItem: (item: GearboxModel) => void;
}

function ConfigurationSimpleStep(props: Props) {
    const { defaultActive, imgDirectory, imgPrefix, url, onChangeStepItem } = props;

    const [active, setActive] = useState<GearboxModel>(defaultActive);

    const { fetchData, loading } = useFetch<GearboxModel[]>(url)

    return (
        (loading)
            ?
            <LoadingWrapperBox> <CircularProgress size={50} /> </LoadingWrapperBox>
            :
            <ConfigurationStepWrapperBox>
                {fetchData?.map((gearbox, idx) =>
                    <ConfigurationItemExtendedCard
                        key={idx}
                        importantInfo={[gearbox.type]}
                        imgDirectory={(`${imgDirectory}`)}
                        imgName={(`${imgPrefix}-0.png`)}
                        additionalInfo={[
                            `Amount of gears: ${gearbox.gearsCount}`,
                        ]}
                        onClickHandler={() => {
                            setActive(gearbox)
                            onChangeStepItem(gearbox)
                        }}
                        isActive={isEqual(gearbox, active)} />
                )}
            </ConfigurationStepWrapperBox>
    )
}

export default ConfigurationSimpleStep