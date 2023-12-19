import React, {useState} from 'react';
import styles from './empl.module.css'
import {IEmplHR} from "../../../models";

interface ProgressBarProps{
    empls: IEmplHR
    name: string
}
export function ProgressBar({empls, name} : ProgressBarProps){
    const checkNam = (name.split(' '))[0];
    const foundEmpl = empls.value.find(function (el) {
        return el.name == checkNam
    })

    // @ts-ignore
    const completeStep = foundEmpl.completeStep
    // @ts-ignore
    const totalStep = foundEmpl.totalStep
    console.log(completeStep)
    return(
        <div className={styles.container}>
            <div className={styles.progressBar}>
                <div
                    className={styles.progressBarFill}
                    style={
                    {
                        width: `${(completeStep * 100) / totalStep}%`
                    }
                    }
                ></div>
            </div>
            <div className={styles.progressLabel}>
                {completeStep} из {totalStep}
            </div>
        </div>
    )
}