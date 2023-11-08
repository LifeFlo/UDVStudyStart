import ModalWithCompanion from "../../component/ModalWithCompanion";
import styles from "../../component/modal.module.css";
import React from "react";
import {useState} from "react";
import {text} from "stream/consumers";
export default function Game() {
    // const [isOpen, setIsOpen] = useState(false)

    return (
        <div className={styles.background}>
            {/*<div>*/}
            {/*    <h1>Game</h1>*/}
            {/*    <input type={"button"} onClick={() => setIsOpen(!isOpen)} style={{height: "50px", width: "30px"}}/>*/}
            {/*</div>*/}
            {/*{isOpen && <ModalWithCompanion  Header={"Приветсвтенная речь"}*/}
            {/*                                  paragraph={"Равным образом тыры пыры тыры пыры"}/>*/}
            {/*}*/}
            <h1 className={styles.text}>GAME</h1>
            <div>
                <button className={styles.btnImg4}></button>
                <button className={styles.btnImg6}></button>
            </div>
            <div>
                <button className={styles.btnImg1}></button>
                <button className={styles.btnImg3}></button>
            </div>
            <div>
                <button className={styles.btnImg2}></button>
                <button className={styles.btnImg5}></button>
            </div>




        </div>
    );
}