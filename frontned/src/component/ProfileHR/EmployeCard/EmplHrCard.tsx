import React, {useRef, useState} from 'react';
import styles from './empl.module.css'
import {listEmplHr} from '../../../data/listEmplHr';
import {Scrollbar} from "smooth-scrollbar-react";
import type {Scrollbar as BaseScrollbar} from "smooth-scrollbar/scrollbar";

export function EmplHrCard() {
    const key = 'fio';
    const sorted = listEmplHr.sort((user1, user2) => user1[key] > user2[key] ? 1 : -1);
    const scroller = useRef<BaseScrollbar | null>(null)
    const [value, setValue] = useState('')
    var newar = listEmplHr.map((e) => e.fio)
    const filter = newar.filter(fio => {
        return fio.toLowerCase().includes(value.toLowerCase())
    })

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
                    {filter.map(item => (
                        <div key={item} className={styles.empl}>
                            {item}
                        </div>
                    ))}
                </div>
            </Scrollbar>
        </div>
    )
}