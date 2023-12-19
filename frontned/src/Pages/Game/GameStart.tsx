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
export default function GameStart() {
    const [isModalActive, setModalActive] = useState(false);
    const handleModalOpen = () => {
        setModalActive(true);
    };
    const handleModalClose = () => {
        setModalActive(false);
    };

    const [isModalActiveBon, setModalActiveBon] = useState(false);
    const handleModalOpenBon = () => {
        setModalActiveBon(true);
    };
    const handleModalCloseBon = () => {
        setModalActiveBon(false);
    };

    const [isModalActiveAdapt, setModalActiveAdapt] = useState(false);
    const handleModalOpenAdapt = () => {
        setModalActiveAdapt(true);
    };
    const handleModalCloseAdapt = () => {
        setModalActiveAdapt(false);
    };

    const [isModalActiveFirst, setModalActiveFirst] = useState(false);
    const handleModalOpenFirst = () => {
        setModalActiveFirst(true);
    };
    const handleModalCloseFirst = () => {
        setModalActiveFirst(false);
        window.location.assign('/profile');
    };
    const lunchPl = () => {
        window.location.assign('/LunchPlanet');
    }

    const transPl = () => {
        window.location.assign('/TransportPlanet');
    }

    const holPl = () => {
        window.location.assign('/HolidayPlanet');
    }

    const exit = () => {
        window.location.assign('/profile');
    }

    return (
        <div className={styles.parent}>
            <div className={styles.background}>
                <button
                    onClick={exit}
                >
                    Exit
                </button>
                <button
                    className={styles.btnModalHello}
                    onClick={handleModalOpen}
                ></button>

                <button
                    className={styles.btnImg1}
                    onClick={handleModalOpenBon}
                >
                </button>
                <p className={styles.name1}>Бонусы</p>
                <button className={styles.btnImg2} onClick={lunchPl}></button>
                <p className={styles.name2}>Обед</p>
                <button className={styles.btnImg3} onClick={transPl}></button>
                <p className={styles.name3}>Транспорт</p>
                <button className={styles.btnImg4} onClick={holPl}></button>
                <p className={styles.name4}>Отпуск/больничный</p>
                <button className={styles.btnImg5} onClick={handleModalOpenAdapt}></button>
                <p className={styles.name5}>Адаптационный период</p>
                <button className={styles.btnImg6} onClick={handleModalOpenFirst}></button>
                <p className={styles.name6}>Первый день</p>

                {isModalActiveBon && (
                    <Modal title="Бонусы" onClose={handleModalCloseBon}>
                        <p>
                            <span className={styles.mark}>Равным образом</span> постоянное информационно-пропагандистское обеспечение нашей деятельности позволяет оценить значение существенных финансовых и административных условий.
                        </p>
                        <p>
                            С другой стороны сложившаяся <span className={styles.mark}>структура организации</span> позволяет оценить значение дальнейших направлений развития.
                        </p>
                        <p>
                            Задача организации, в особенности же постоянное информационно-пропагандистское обеспечение нашей деятельности позволяет оценить значение новых предложений.
                        </p>
                    </Modal>
                )}

                {isModalActiveAdapt && (
                    <Modal title="Адаптационный период" onClose={handleModalCloseAdapt}>
                        <p>
                            <span className={styles.mark}>Равным образом</span> постоянное информационно-пропагандистское обеспечение нашей деятельности позволяет оценить значение существенных финансовых и административных условий.
                        </p>
                        <p>
                            С другой стороны сложившаяся <span className={styles.mark}>структура организации</span> позволяет оценить значение дальнейших направлений развития.
                        </p>
                        <p>
                            Задача организации, в особенности же постоянное информационно-пропагандистское обеспечение нашей деятельности позволяет оценить значение новых предложений.
                        </p>
                    </Modal>
                )}

                {isModalActiveFirst && (
                    <Modal title="Первый день" onClose={handleModalCloseFirst}>
                        <p>
                            <span className={styles.mark}>Равным образом</span> постоянное информационно-пропагандистское обеспечение нашей деятельности позволяет оценить значение существенных финансовых и административных условий.
                        </p>
                        <p>
                            С другой стороны сложившаяся <span className={styles.mark}>структура организации</span> позволяет оценить значение дальнейших направлений развития.
                        </p>
                        <p>
                            Задача организации, в особенности же постоянное информационно-пропагандистское обеспечение нашей деятельности позволяет оценить значение новых предложений.
                        </p>
                    </Modal>
                )}
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
            </div>
        </div>
    );
}