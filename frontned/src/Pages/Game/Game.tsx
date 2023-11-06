import ModalWithCompanion from "../../component/ModalWithCompanion";
import {useState} from "react";
export default function Game() {
    const [isOpen, setIsOpen] = useState(false)

    return (
        <div>
            <div>
                <h1>Game</h1>
                <input type={"button"} onClick={() => setIsOpen(!isOpen)} style={{height: "50px", width: "30px"}}/>
            </div>
            {isOpen && <ModalWithCompanion  Header={"Приветсвтенная речь"}
                                              paragraph={"Равным образом тыры пыры тыры пыры"}/>
            }
        </div>

    );
}