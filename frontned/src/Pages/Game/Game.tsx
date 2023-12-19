import ModalWithCompanion from "../../component/Game/ModalSpace/ModalWithCompanion";
import styles from "./game.module.css";
import ModalHello from "./modalHello/modalWindow/ModalHello";
import React from "react";
import {useState} from "react";
import Modal from "../../component/Game/ModalSpace/ModalWithCompanion";
import IconButton from "@mui/material/IconButton";
import {ThemeProvider} from "@mui/material";
import FastForwardOutlinedIcon from "@mui/icons-material/FastForwardOutlined";
import {createTheme} from "@mui/material/styles";
import {teal} from "@mui/material/colors";

const theme = createTheme({
    palette: {
        primary: {
            main: teal[300],
        },
        secondary: {
            main: '#f44336',
        },
    },
});
export default function Game() {
    const [isModalActive, setModalActive] = useState(true);
    const handleModalClose = () => {
        setModalActive(false);
        window.location.assign('/GameStart');
    };


    return (
        <div className={styles.parent}>
            <div className={styles.background}>
                {isModalActive && (
                    <ModalHello title="Приветственная речь" onClose={handleModalClose}>
                        <p>
                            Добро пожаловать в команду <span className={styles.mark}>UDV Group</span>! Эта новелла создана для того, чтобы ты ознакомился с основной информацией о твоей новой работе.
                        </p>
                        <p>
                            Путешествуй по планетам вместе с осьминогом и узнавай много нового о вселенной нашей компании. Удачи тебе!                        </p>
                        <p>
                            *У тебя всегда есть возможность пропустить новеллу с помощью выхода в правом верхнем углу, но мы этого конечно же не советуем.                        </p>
                    </ModalHello>
                )}
                <button className={styles.btnImg1}>
                </button>
                <p className={styles.name1}>Бонусы</p>
                <button className={styles.btnImg2} ></button>
                <p className={styles.name2}>Обед</p>
                <button className={styles.btnImg3} ></button>
                <p className={styles.name3}>Транспорт</p>
                <button className={styles.btnImg4} ></button>
                <p className={styles.name4}>Отпуск/больничный</p>
                <button className={styles.btnImg5}></button>
                <p className={styles.name5}>Адаптационный период</p>
                <button className={styles.btnImg6}></button>
                <p className={styles.name6}>Первый день</p>


            </div>
        </div>
    );
}