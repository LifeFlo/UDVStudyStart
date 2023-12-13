import React, {useState} from "react";
import styles from "./hol.module.css"
import IconButton from "@mui/material/IconButton";
import {ThemeProvider} from "@mui/material";
import FastForwardOutlinedIcon from "@mui/icons-material/FastForwardOutlined";
import { createTheme } from '@mui/material/styles';
import { teal} from '@mui/material/colors';

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

export default function LunchPlanet() {
    const [hol1, setHol1] = useState(false)
    const hol2 = () => {
        window.location.assign('/game');
    }
    return(
        <div className={styles.parent}>
            {
                hol1 ?
                    <div className={styles.bacHol2}>
                        <div className={styles.dialog}>
                            <div className={styles.mascot}></div>
                            <p className={styles.text}>На первом этаже ты можешь найти Food story (лобби-бар). В котором ты можешь вкусно перекусить, попить чай или кофе.</p>
                            <div className={styles.bntPos}>
                                <IconButton
                                    onClick={hol2}
                                >
                                    <ThemeProvider theme={theme}>
                                        <FastForwardOutlinedIcon color="primary" fontSize="large"/>
                                    </ThemeProvider>
                                </IconButton>
                            </div>
                        </div>

                    </div>
                    :
                    <div className={styles.bacHol1}>
                        <div className={styles.dialog}>
                            <p className={styles.text}>Ого! Посмотри какой тут красивый бургер, даже захотелось пообедать. Давай расскажу тебе о том, где ты сможешь это сделать.</p>
                            <div className={styles.bntPos}>
                                <IconButton
                                    onClick={() => setHol1(true)}
                                >
                                    <ThemeProvider theme={theme}>
                                        <FastForwardOutlinedIcon color="primary" fontSize="large"/>
                                    </ThemeProvider>
                                </IconButton>
                            </div>
                        </div>
                        <div className={styles.mascot}></div>
                    </div>
            }
        </div>
    )
}