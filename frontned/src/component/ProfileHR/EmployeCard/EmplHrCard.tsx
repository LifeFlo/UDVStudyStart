import React, {useRef, useState} from 'react';
import styles from './empl.module.css'
import {ListEmplHr} from '../../../data/listEmplHr';
import {Scrollbar} from "smooth-scrollbar-react";
import type {Scrollbar as BaseScrollbar} from "smooth-scrollbar/scrollbar";
import {EmplHr} from "./EmplHr";
import axios from "axios";

export function EmplHrCard() {
    const token = localStorage.getItem('token')
    const [data, setData] = useState(ListEmplHr)
    const [check, setCheck] = useState(false)

    if(!check) {
        axios.get(
            'http://37.139.43.80:80/api/hr/my/employee',
            {headers: {Authorization: `Bearer ${token}`}},
        )
            .then(r => setData(r.data))
        setCheck(true)
    }
    console.log(data)

    const scroller = useRef<BaseScrollbar | null>(null)
    const [value, setValue] = useState('')

    return(
        <div className={styles.pos}>
            <Scrollbar ref = {scroller}>
                <p className={styles.title}>Сотрудники</p>
                <form>
                    <input
                        className={styles.search}
                        type="text"
                        placeholder="Поиск"
                        onChange={(event) => setValue(event.target.value)}
                    />
                </form>
                <div className={styles.scrollBar}>
                    <EmplHr empls={data} value = {value}/>
                </div>
            </Scrollbar>
        </div>
    )
}