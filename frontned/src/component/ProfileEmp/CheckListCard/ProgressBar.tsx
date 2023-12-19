import React, {useState} from 'react';
import styles from "./checkList.module.css";
import {ITask} from "../../../models";

interface ProgressBarProps{
    empls: ITask
}
export function ProgressBar({empls} : ProgressBarProps){
    const compl = empls.value.map((item) => (
        item.isComplete
    ))

    // @ts-ignore
    const totalStep = empls.value.length
    const completeStep = (compl.length*100) / totalStep
    console.log(completeStep)
    return(
        <div>
            <div className={styles.progressBar}>
                <div id="numder">
                </div>
            </div>
            <svg
                width="200" height="187" viewBox="0 0 180 180" fill="none"
                className={styles.prog}
            >
                <defs>
                    <linearGradient id="color">
                        <stop offset="0%" stopColor="#7E13AB"/>
                        <stop offset="100%" stopColor="#7E13AB"/>
                    </linearGradient>
                </defs>
                <circle
                    id="progerssBar"
                    cx="80" cy="81" r="66"
                    strokeLinecap="round"
                />
            </svg>
        </div>
    )
}