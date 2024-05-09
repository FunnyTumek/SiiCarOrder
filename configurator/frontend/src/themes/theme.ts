import { createTheme, Theme } from "@mui/material/styles";
const theme: Theme = createTheme({
  palette: {
    mode: "light",
  },
  breakpoints: {
    values: {
      xs: 0,
      sm: 650,
      md: 1024,
      lg: 2048,
      xl: 3840
    }

  }
})
export default theme;