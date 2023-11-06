import Modal from "react-modal";
import styles from "./modal.module.css"
import TextInModal from "./TextInModal";

interface props {
    Header: string,
    paragraph: string,
}
export default function ModalWithCompanion (props: props) {
    return(
        <div className={styles.parent}>
            <Modal className={styles.modal} isOpen>
                <TextInModal Header={props.Header} Paragraph={props.paragraph}/>
            </Modal>
        </div>
    )// кидать через childer возможно не самое лучшее решение
}