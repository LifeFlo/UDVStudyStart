import Modal from "react-modal";
import styles from "./modal.module.css"
import TextInModal from "./TextInModal/TextInModal";
import {useState} from "react";
import setIsOpen from "../Pages/Game/Game"

interface props {
    Header: string,
    paragraph: string,
}

const customStyles = {
    overlay: {
        backgroundColor: "rgba(0, 0, 0, 0)"
    },
};
export default function ModalWithCompanion (props: props) {
    return (
        <div className={styles.parent}>
            <div className={styles.modalNameCompanion}>
                <h4 className={styles.nameCompanion}> Маскот </h4>
            </div>

            <Modal className={styles.modal} style={customStyles} isOpen portalClassName={styles.outerModal}>

                <TextInModal Header={props.Header} Paragraph={props.paragraph}/>
                <button>Дальше</button>
                <button onClick={() => setIsOpen}>Назад</button>
            </Modal>

        </div>
    );// кидать через childer возможно не самое лучшее решение
}