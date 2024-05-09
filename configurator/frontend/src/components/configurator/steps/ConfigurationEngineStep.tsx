import React, { useState } from 'react'
import EngineModel from '../../../models/EngineModel';
import ConfigurationItemExtendedCard from '../item-cards/ConfigurationItemExtendedCard';
import isEqual from 'lodash.isequal';
import { useFetch } from '../../../customHooks/useFetch';
import { CircularProgress } from '@mui/material';
import { ConfigurationStepWrapperBox, LoadingWrapperBox } from './ConfigurationStepStyle';

type Props = {
    defaultActive: EngineModel,
    imgDirectory: string,
    imgPrefix: string,
    url: string,
    onChangeStepItem: (item: EngineModel) => void;
}

function ConfigurationSimpleStep(props: Props) {
    const { defaultActive, imgDirectory, imgPrefix, url, onChangeStepItem } = props;

    const [active, setActive] = useState<EngineModel>(defaultActive);

    const { fetchData, loading } = useFetch<EngineModel[]>(url)

    return (
        (loading)
            ?
            <LoadingWrapperBox> <CircularProgress size={50} /> </LoadingWrapperBox>
            :
            <ConfigurationStepWrapperBox>
                {fetchData?.map((engine, idx) =>
                    <ConfigurationItemExtendedCard
                        key={idx}
                        importantInfo={[engine.name]}
                        imgDirectory={(`${imgDirectory}`)}
                        imgName={(`${imgPrefix}-0.png`)}
                        additionalInfo={[
                            `Type: ${engine.type}`,
                            `Capacity: ${engine.capacity}`,
                            `Power: ${engine.power}`,
                        ]}
                        onClickHandler={() => {
                            setActive(engine)
                            onChangeStepItem(engine)
                        }}
                        isActive={isEqual(engine, active)} />
                )}
            </ConfigurationStepWrapperBox>
    )
}

export default ConfigurationSimpleStep
