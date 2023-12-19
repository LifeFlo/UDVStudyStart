import React, {useState} from "react";
import styles from "./emplCard.module.css"
import axios from "axios";


export function EmplCard(){
    const [name, setName] = useState()
    const [surname, setSurname] = useState()
    const [midl, setMidl] = useState()
    const [mail, setMail] = useState()

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
        .then(r => setMidl(r.data.value.middleName))
    axios.get(
        'http://37.139.43.80:80/api/account',
        {headers: {Authorization: `Bearer ${token}`}},
    )
        .then(r => setMail(r.data.value.email))

    let nam = name
    let ser = surname
    let mid = midl
    let mal = mail


    const onClickExit = () => {
        window.location.assign('/auth');
        window.localStorage.removeItem('token')
    }

    return(
        <div className={styles.card}>
            <div className={styles.ava}></div>
            <div className={styles.fio}>
                {nam} <span>{ser}</span> <span>{mid}</span>
            </div>
            <div className={styles.contactTitle}>
                Почта
            </div>
            <div className={styles.contact}>
                {mal}
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
