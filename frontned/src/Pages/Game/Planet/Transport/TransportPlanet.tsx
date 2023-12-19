import React, {useState} from "react";
import styles from "./transport.module.css"
import IconButton from "@mui/material/IconButton";
import {ThemeProvider} from "@mui/material";
import FastForwardOutlinedIcon from "@mui/icons-material/FastForwardOutlined";
import {createTheme} from "@mui/material/styles";
import {teal} from "@mui/material/colors";

const theme = createTheme({
    palette: {
        primary: {
            main: teal[300],
        },
        secondary: {
            main: '#f44336',
        },
    },
});

export default function TransportPlanet() {
    const transport = () => {
        window.location.assign('/GameStart');
    }
    return(
        <div className={styles.parent}>
            <div className={styles.dialogTitle}>
                <p className={styles.dialogTitleText}>Маскот</p>
            </div>
            <div className={styles.bacTrans}>
                <div className={styles.dialog}>
                    <p className={styles.text}>На этой планете слишком много пробок, но хочу тебя обрадовать, что в нашей компании таких проблем не будет. У нас отличная транспортная доступность, а также существует корпоративное такси.</p>
                    <div className={styles.bntPos}>
                        <IconButton
                            onClick={transport}
                        >
                            <ThemeProvider theme={theme}>
                                <FastForwardOutlinedIcon color="primary" fontSize="large"/>
                            </ThemeProvider>
                        </IconButton>
                    </div>
                </div>
                <div className={styles.mascot}></div>
            </div>
        </div>
    )
}