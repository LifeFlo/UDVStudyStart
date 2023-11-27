import React from "react";
import {Link} from "react-router-dom";
import styles from "../../modal.module.css"

export function NavigationForLK(){
    return(
        <nav className={styles.nav}>
            <span className={styles.navLogo}>
                UDV|Group
            </span>
            <span>
                <li>
                    <Link to="/info" className={styles.navLink}>
                        Главная
                    </Link>
                </li>
                <li>
                    <Link to="/Bonus" className={styles.navLink}>
                        Бонусы
                    </Link>
                </li>
                <li>
                    <Link to="/JobWithUniv" className={styles.navLink}>
                        Работа с вузами
                    </Link>
                </li>
                <li>
                    <Link to="/Sience" className={styles.navLink}>
                        Научная деятельность
                    </Link>
                </li>
                <li>
                    <Link to="/Documents" className={styles.navLink}>
                        Документы
                    </Link>
                </li>
                <li>
                    <Link to="/Contacts" className={styles.navLink}>
                        Контакты
                    </Link>
                </li>
            </span>
        </nav>
    )
}