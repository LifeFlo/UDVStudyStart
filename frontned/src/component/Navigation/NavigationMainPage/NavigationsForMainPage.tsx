import React from "react";
import {Link} from "react-router-dom";
import styles from "../../modal.module.css"

export function NavigationsForMainPage(){
    return(
        <nav className={styles.nav}>
            <span>
                UDV|Group
            </span>
            <span>
                <Link to="/profile" className={styles.navLink}>
                   Личный кабинет
                </Link>
                <Link to="/game" className={styles.navLink}>
                    Игра
                </Link>
            </span>
        </nav>
    )
}