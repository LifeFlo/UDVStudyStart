import {NavigationForLK} from "../../component/NavigationForLK"
import {Route, Routes} from "react-router-dom";
import Game from "../Game/Game";
import React, {useEffect, useState} from "react";
import Info from "../Info/Info";
import styles from "../../component/modal.module.css";
import axios from 'axios'
import {Tasks} from "../../component/checkList";
import {task} from "../../data/checkListData";

const src = "https://jsonplaceholder.typicode.com/posts"

export default function Profile() {
    const [value, setValue] = useState([])
    useEffect(() => {
        axios
            .get(src)
            .then(data => {
                setValue(data.data[1].title)
            })
    }, []);
    const [checkList, setCheckList] = useState(false)
    return (
        <div>
            <>
                <NavigationForLK />
                <Routes>
                        <Route path ="/info" element={ <Info />}/>
                        <Route path ="/about" element={ <Info />}/>
                        <Route path ="/about" element={ <Info />}/>
                        <Route path ="/about" element={ <Info />}/>
                        <Route path ="/about" element={ <Info />}/>
                        <Route path ="/about" element={ <Info />}/>
                        <Route path ="/about" element={ <Info />}/>
                </Routes>
            </>
            <h1 className={styles.h1Prof}>Личный кабинет</h1>

            <div className={styles.cardLk}>
                <div className={styles.cardAva}>
                    <p className={styles.name}>ФИО{value}</p>
                    <p className={styles.job}>Должность{value}</p>
                    <div className={styles.avaPic}></div>
                </div>
                <div className={styles.cardNast}>
                    <p>ФИО{value}</p>
                    <p>Адаптационный период:{value}</p>
                    <p>Телефон:{value}</p>
                    <p>Почта:{value}</p>
                    <div className={styles.infoNast}>
                        <p>Личный наставник {value}</p>
                        <p>ФИО Наствника {value}</p>
                        <p>Телефон:{value}</p>
                        <p>Почта:{value}</p>
                    </div>
                </div>
                {
                    checkList ?
                        <div className={styles.progressCard}>
                            <p>CheckList</p>
                            <Tasks task = {task[0]} />
                            <Tasks task = {task[1]} />
                            <Tasks task = {task[2]} />
                            <Tasks task = {task[3]} />
                            <button
                                onClick={() => setCheckList(false)}
                            >
                                Back
                            </button>
                        </div>
                        :
                        <div className={styles.learn}>
                            <div className={styles.firstCard}>
                                <p>first day</p>
                                <button
                                    onClick={() => setCheckList(true)}
                                > Посмотреть
                                </button>
                            </div>
                            <div className={styles.notesCard}>
                                <p>заметки</p>
                                <button> Посмотреть</button>
                            </div>
                            <div>
                                <p>Прогресс</p>
                                <p>1 из 7</p>
                            </div>
                        </div>
                }
            </div>
        </div>
    )
}