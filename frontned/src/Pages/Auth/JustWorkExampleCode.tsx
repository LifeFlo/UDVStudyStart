import {useEffect, useState} from "react";
import {IResponse} from "../../Infrastructure/IResponse";
import axios from "axios";

export default function WorkExample() {
    const [ResponseAuth, setResponseAuth] = useState<IResponse<String>>();
    const [UserName, setUserName] = useState<string>();
    const [UserPassword, setPassword] = useState<string>();
    const [click, setClick] = useState<Boolean>();

    useEffect(() => {
           axios.post(sa,fs,{headers: "Authohization"})
        , [click])



    return(
        <div>
            <button onClick={() => setClick(!click)}> нажми </button>
    <input type={"text"} onChange={e => setUserName(e.target.value)} placeholder={"name"}/>
    <input type={"text"} onChange={e => setPassword(e.target.value)} placeholder={"password"}/>
    <h1>Старница авторизаций</h1>
    <p> авторизация ааааа</p>
    </div>
)
}