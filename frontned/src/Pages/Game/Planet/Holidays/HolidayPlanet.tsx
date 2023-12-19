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
        window.location.assign('/GameStart');
    }
    return(
        <div className={styles.parent}>
            {
                hol1 ?
                    <div className={styles.bacHol2}>
                        <div className={styles.mascot}></div>
                        <div className={styles.dialogTitle}>
                            <p className={styles.dialogTitleText}>Маскот</p>
                        </div>
                        <div className={styles.dialog}>
                            <p className={styles.text}>К сожалению, иногда отдых бывает не таким радостным, а точнее я сейчас про больничный. Пора узнать как на него выйти.</p>
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
                        <div className={styles.mascot}></div>
                        <div className={styles.dialogTitle}>
                            <p className={styles.dialogTitleText}>Маскот</p>
                        </div>
                        <div className={styles.dialog}>
                            <p className={styles.text}>Когда много работаешь, то обязательно необходимо прописывать себе отдых, чтобы восстановить силы и вернуться к работе воодушевлённым. Сейчас расскажу тебе, какие у нас правила.</p>
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

                    </div>
            }
        </div>
    )
}