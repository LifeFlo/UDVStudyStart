import React, {useState} from "react";
import styles from "./lunch.module.css"
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
    const [lunch1, setLunch1] = useState(false)
    const [lunch2, setLunch2] = useState(false)
    const lunch3 = () => {
        window.location.assign('/GameStart');
    }
    return(
        <div className={styles.parent}>
            {
                lunch1 ?
                    <div className={styles.parent}>
                        {
                            lunch2 ?
                                <div className={styles.bacLunch3}>
                                    <div className={styles.dialogTitle}>
                                        <p className={styles.dialogTitleText}>Маскот</p>
                                    </div>
                                    <div className={styles.dialog}>
                                        <p className={styles.text}>А если немного пройтись, то ты найдёшь уютное кафе “Пятница”.  Там можно попробовать бизнес-ланчи, кондитерские изделия и ароматный кофе.
                                            <br/>Приятного тебе аппетита!</p>
                                        <div className={styles.bntPos}>
                                            <IconButton
                                                onClick={lunch3}
                                            >
                                                <ThemeProvider theme={theme}>
                                                    <FastForwardOutlinedIcon color="primary" fontSize="large"/>
                                                </ThemeProvider>
                                            </IconButton>
                                        </div>
                                    </div>
                                    <div className={styles.mascot}></div>
                                </div>
                                :
                                <div className={styles.bacLunch2}>
                                    <div className={styles.dialogTitle}>
                                        <p className={styles.dialogTitleText}>Маскот</p>
                                    </div>
                                    <div className={styles.dialog}>
                                        <p className={styles.text}>На первом этаже ты можешь найти Food story (лобби-бар). В котором ты можешь вкусно перекусить, попить чай или кофе.</p>
                                        <div className={styles.bntPos}>
                                            <IconButton
                                                onClick={() => setLunch2(true)}
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
                    :
                    <div className={styles.bacLunch1}>
                        <div className={styles.dialogTitle}>
                            <p className={styles.dialogTitleText}>Маскот</p>
                        </div>
                        <div className={styles.dialog}>
                            <p className={styles.text}>Ого! Посмотри какой тут красивый бургер, даже захотелось пообедать. Давай расскажу тебе о том, где ты сможешь это сделать.</p>
                            <div className={styles.bntPos}>
                                <IconButton
                                    onClick={() => setLunch1(true)}
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