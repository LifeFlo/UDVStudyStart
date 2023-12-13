import ModalWithCompanion from "../../component/Game/ModalSpace/ModalWithCompanion";
import styles from "./game.module.css";
import React from "react";
import {useState} from "react";
import Modal from "../../component/Game/ModalSpace/ModalWithCompanion";


export default function Game() {
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
    };

    const bonPl = () => {
        window.location.assign('/BonusPlanet');
    }

    const lunchPl = () => {
        window.location.assign('/LunchPlanet');
    }

    const transPl = () => {
        window.location.assign('/TransportPlanet');
    }

    const holPl = () => {
        window.location.assign('/HolidayPlanet');
    }

    return (
        <div className={styles.parent}>
            <div className={styles.background}>
                <button className={styles.btnImg1} onClick={handleModalOpenBon}></button>
                <button className={styles.btnImg2} onClick={lunchPl}></button>
                <button className={styles.btnImg3} onClick={transPl}></button>
                <button className={styles.btnImg4} onClick={holPl}></button>
                <button className={styles.btnImg5} onClick={handleModalOpenAdapt}></button>
                <button className={styles.btnImg6} onClick={handleModalOpenFirst}></button>
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
            </div>
        </div>
    );
}