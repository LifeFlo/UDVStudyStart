import ModalWithCompanion from "../../component/ModalWithCompanion";
import styles from "../../component/modal.module.css";
import React from "react";
import {useState} from "react";
import {text} from "stream/consumers";
export default function Game() {
    const [isOpen, setIsOpen] = useState(false)

    return (
        <div className={styles.background}>

            <h1 className={styles.text}>GAME</h1>
            <div>
                <button className={styles.btnImg4} onClick={() => setIsOpen(!isOpen)}></button>
                <button className={styles.btnImg6} onClick={() => setIsOpen(!isOpen)}></button>
            </div>
            <div>
                <button className={styles.btnImg1} onClick={() => setIsOpen(!isOpen)}></button>
                <button className={styles.btnImg3} onClick={() => setIsOpen(!isOpen)}></button>
            </div>
            <div>
                <button className={styles.btnImg2} onClick={() => setIsOpen(!isOpen)}></button>
                <button className={styles.btnImg5} onClick={() => setIsOpen(!isOpen)}></button>
            </div>

            {isOpen &&
                <ModalWithCompanion
                    Header={"Приветсвтенная речь"}
                    paragraph={"Равным образом тыры пыры тыры пыры"}
                />
            }
        </div>
    );
}