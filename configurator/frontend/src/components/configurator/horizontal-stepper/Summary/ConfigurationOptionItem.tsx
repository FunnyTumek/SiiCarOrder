import EditIcon from '@mui/icons-material/Edit';
import { ColumnContent, ColumnName, EditButton, OptionContentWrapper, OptionText, OptionTextContentWrapper } from './SummaryStyle/ConfigurationOptionItemStyle';

type Props = {
    setActiveStep: (step: number) => void,
    activeStep: number,
    columnName: String[]
    columnContent: String[]
    children: React.ReactNode
}

const ConfigurationOptionItem = (props: Props) => {
    const { setActiveStep, activeStep, columnName, columnContent } = props

    return (
        <OptionContentWrapper>
            <OptionTextContentWrapper>
                <ColumnName>
                    {columnName.map(i => <OptionText>{i}</OptionText>)}
                </ColumnName>
                <ColumnContent  >
                    {columnContent.map(i => <OptionText>{i.toUpperCase()}</OptionText>)}
                </ColumnContent>
            </OptionTextContentWrapper>
            <EditButton onClick={() => setActiveStep(activeStep)}> <EditIcon /> </EditButton>
        </OptionContentWrapper>
    )
}

export default ConfigurationOptionItem

