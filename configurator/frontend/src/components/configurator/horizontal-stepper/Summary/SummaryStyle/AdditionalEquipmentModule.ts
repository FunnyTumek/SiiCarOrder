import { Grid, IconButton, Paper, styled, Typography } from "@mui/material";

export const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#fff",
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: "center",
    color: theme.palette.text.secondary,
    '&:hover .MuiIconButton-root': {
        background: 'transparent',
        color: "gray",
    },
}));

export const SummaryText = styled(Typography)(
    ({ theme }) => `
  font-size:${theme.typography.h5.fontSize};
  `
);

export const AdditionalEquipment = styled(Grid)(({ theme }) => ({
    borderBottom: `1px solid ${theme.palette.primary.main}`,
}));

export const AdditionalEquipmentBox = styled(Grid)(({ theme }) => ({
    padding: 8,
    position: "relative"
}));

export const AdditionalEquipmentDeleteButton = styled(IconButton)(({ theme }) => ({
    color: 'transparent',
    position: 'absolute',
    bottom: '24px',
    right: '-12px',
    transition: theme.transitions.create(['color'], {
        duration: theme.transitions.duration.standard,
    })
}));