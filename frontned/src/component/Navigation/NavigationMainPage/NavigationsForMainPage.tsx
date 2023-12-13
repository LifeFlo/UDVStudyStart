import React from "react";
import {Link} from "react-router-dom";
import styles from "./nav.module.css"

export function NavigationsForMainPage(){
    return(
        <nav className={styles.parent}>
            <span className={styles.nav}>
                UDV|Group
            </span>
            <nav >
                <Link to="/info" className={styles.nav}>
                    Главная
                </Link>

                <Link to="/Bonus" className={styles.nav}>
                    Бонусы
                </Link>

                <Link to="/JobWithUniv" className={styles.nav}>
                    Работа с вузами
                </Link>

                <Link to="/Sience" className={styles.nav}>
                    Научная деятельность
                </Link>

                <Link to="/Documents" className={styles.nav}>
                    Документы
                </Link>

                <Link to="/Contacts" className={styles.nav}>
                    Контакты
                </Link>
                <Link to="/profile" className={styles.nav}>
                    Личный кабинет
                </Link>
                <Link to="/game" className={styles.nav}>
                    Игра
                </Link>
            </nav>
        </nav>
    )
}