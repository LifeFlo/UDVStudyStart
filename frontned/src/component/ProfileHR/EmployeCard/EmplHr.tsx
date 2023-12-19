import React from 'react';
import styles from './empl.module.css'
import {IEmplHR} from "../../../models";
import {ProgressBar} from "./ProgressBar";

interface EmplHrProps{
    empls: IEmplHR
    value: string
}

export function EmplHr({empls, value} : EmplHrProps){
    var listEmplHr = empls.value.map(item =>(
        item.name + ' ' + item.surname + ' ' + item.middleName
    ))
    const filter = listEmplHr.filter(fio => {
        return fio.toLowerCase().includes(value.toLowerCase())
    })
    return(
        <div>
            {
                filter.map(item => (
                    <div key={item} className={styles.empPos}>
                        <p className={styles.empl}>{item}</p>
                        <ProgressBar empls={empls} name={item}/>
                    </div>
                ))
            }
        </div>
    )
}