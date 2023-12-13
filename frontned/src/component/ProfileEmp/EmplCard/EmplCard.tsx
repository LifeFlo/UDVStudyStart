import React from "react";
import styles from "./emplCard.module.css"
import axios from "axios";


export function EmplCard(){

    // const request =
    //     axios.post("http://37.139.43.80:80/api/auth",
    //         {email: "turnickii.n@gmail.com", password: "123123"})
    // console.log(request)
    //
    // const t = fetch("http://37.139.43.80:80/api/account")
    //
    // console.log(t)

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
