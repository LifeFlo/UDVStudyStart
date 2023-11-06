
interface props {
    Header: string,
    Paragraph: string
}
export default function TextInModal(props: props) {
    return (
        <div>
            <h1>{props.Header}</h1>
            <p>{props.Paragraph}</p>
        </div>
    )
}