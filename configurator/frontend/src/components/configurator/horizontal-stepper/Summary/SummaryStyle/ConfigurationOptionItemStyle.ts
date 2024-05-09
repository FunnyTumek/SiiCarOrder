import { Card, IconButton, Stack, styled, Typography } from "@mui/material";

export const OptionContentWrapper = styled(Card)(({ theme }) => ({
    display: "flex",
    alignItems: "center",
    justifyContent: "space-between",
    padding: theme.spacing(1),
    borderRadius: 0,
    fontSize: theme.typography.subtitle1.fontSize,
    backgroundColor: theme.palette.background.paper,
    '&:hover .MuiIconButton-root': {
        background: 'transparent',
        width: '50px',
        color: theme.palette.background.paper,
    },
    '&:hover': {
        background: theme.palette.primary.main,
        color: theme.palette.primary.contrastText
    }
}));

export const ColumnName = styled(Stack)(({ theme }) => ({
    width: "50%",
    justifyContent: "center",
    marginLeft: theme.spacing(1)
}));

export const ColumnContent = styled(Stack)(({ theme }) => ({
    width: "50%",
    justifyContent: "center",
    marginLeft: theme.spacing(1),
    textAlign: 'right'
}));

export const OptionTextContentWrapper = styled(Typography)(({ theme }) => ({
    display: "flex",
    flexGrow: 1,

}));

export const OptionText = styled(Typography)(({ theme }) => ({

}));

export const EditButton = styled(IconButton)(({ theme }) => ({
    width: "0px",
    color: 'transparent',
    background: 'transparent',
    transition: theme.transitions.create(['color', 'width'], {
        duration: theme.transitions.duration.standard,
    })
}));