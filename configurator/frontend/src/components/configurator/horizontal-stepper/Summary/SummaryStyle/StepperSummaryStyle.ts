import { Box, Stack, styled, Typography } from "@mui/material";

export const SummaryStack = styled(Stack)(({ theme }) => ({
    padding: theme.spacing(4),
    flexDirection: "column"
}));

export const SummaryText = styled(Typography)(
    ({ theme }) => `
  font-size:${theme.typography.h5.fontSize};
  `
);

export const ConfigurationOptionsAndImgWrapper = styled(Box)(({ theme }) => ({
    display: "flex",
    [theme.breakpoints.up("md")]: { flexDirection: "row" },
    [theme.breakpoints.down("md")]: { flexDirection: "column" },
    alignItems: "center",
    justifyContent: "space-between",
    overflow: "hidden",
    fontWeight: "bold",
    flexShrink: 0,
}));

export const ConfigurationOptionWrapper = styled(Box)(({ theme }) => ({
    flexDirection: "column",
    [theme.breakpoints.up("md")]: { alignItems: "flex-start" },
    [theme.breakpoints.down("xs")]: { alignItems: "center" },
    justifyContent: "space-between",
    padding: 1,
    width: '30%'
}));

export const PriceBox = styled(Box)(({ theme }) => ({
    display: "flex",
    justifyContent: "space-between",
    p: 1,
    m: 1,
    borderBottom: `1px solid ${theme.palette.primary.main}`,
}));