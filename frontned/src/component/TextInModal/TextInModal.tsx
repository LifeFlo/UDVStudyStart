import styles from "./TextInModal.module.css"

interface props {
    Header: string,
    Paragraph: string
}
export default function TextInModal(props: props) {
    return (
        <div className={styles.content} >
            <h1 className={styles.header}>{props.Header}</h1>
            <p>{props.Paragraph}</p>
        </div>
    )
}