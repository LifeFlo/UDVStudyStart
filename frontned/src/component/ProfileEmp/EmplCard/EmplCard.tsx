import React, {useState} from "react";
import styles from "./emplCard.module.css"
import axios from "axios";



export function EmplCard(){
    const [name, setName] = useState()
    const [surname, setSurname] = useState()
    const [email, setEmail] = useState()

    const token = localStorage.getItem('token')
    axios.get(
        'http://37.139.43.80:80/api/account',
        {headers: {Authorization: `Bearer ${token}`}},
    )
        .then(r => setName(r.data.value.name))
    axios.get(
        'http://37.139.43.80:80/api/account',
        {headers: {Authorization: `Bearer ${token}`}},
    )
        .then(r => setSurname(r.data.value.surname))
    axios.get(
        'http://37.139.43.80:80/api/account',
        {headers: {Authorization: `Bearer ${token}`}},
    )
        .then(r => setEmail(r.data.value.email))

    let nam = name
    let ser = surname
    let mail = email


    const onClickExit = () => {
        window.location.assign('/auth');
        window.localStorage.removeItem('token')
    }

    return(
        <div className={styles.card}>
            <div className={styles.fio}>
                {nam}
                {ser}
            </div>
            <div className={styles.contactTitle}>
                Почта
            </div>
            <div className={styles.contact}>
                {mail}
            </div>
            <button
                className={styles.btnExit}
                onClick={() => onClickExit()}
            >
                Выход
            </button>
        </div>
    )
}
