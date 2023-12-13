import React from "react";
import styles from './hrCard.module.css'

export function HrCard(){
    const onClickExit = () => {
        window.location.assign('/auth');
    }

    return(
        <div className={styles.card}>
            <button
                className={styles.btnExit}
                onClick={() => onClickExit()}>
                Выход
            </button>
        </div>
    )
}