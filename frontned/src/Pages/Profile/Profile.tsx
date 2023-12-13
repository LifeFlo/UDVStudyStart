import {NavigationForLK} from "../../component/Navigation/NavigationLkEmp/NavigationForLK"
import {EmplCard} from "../../component/ProfileEmp/EmplCard/EmplCard";
import {AdaptCard} from "../../component/ProfileEmp/AdaptationPeriodCard/AdaptCard";
import {CheckListCard} from "../../component/ProfileEmp/CheckListCard/CheckListCard";
import {CheckList} from "../../component/ProfileEmp/CheckListCard/CheckList/CheckList";
import {NotesCard} from "../../component/ProfileEmp/NotesCard/NotesCard";
import {Notes} from "../../component/ProfileEmp/NotesCard/Notes/Notes";
import {Route, Routes} from "react-router-dom";
import React, {useState} from "react";
import Info from "../Info/Info";
import styles from "./prof.module.css";


const src = "https://jsonplaceholder.typicode.com/posts"

export default function Profile() {
    const [check, setCheck] = useState(false)
    const change = (value: boolean | ((prevState: boolean) => boolean)) => {
        setCheck(value)
    }

    const [notes, setNotes] = useState(false)
    const changeNotes = (value: boolean | ((prevState: boolean) => boolean)) => {
        setNotes(value)
    }

    return (
        <div className={styles.background}>
            <NavigationForLK />
            <Routes>
                <Route path ="/info" element={ <Info />}/>
                <Route path ="/about" element={ <Info />}/>
                <Route path ="/about" element={ <Info />}/>
                <Route path ="/about" element={ <Info />}/>
                <Route path ="/about" element={ <Info />}/>
                <Route path ="/about" element={ <Info />}/>
                <Route path ="/about" element={ <Info />}/>
            </Routes>
            <EmplCard/>
            <AdaptCard/>
            {
                check ?
                    <div>
                        {
                            notes ?
                                <div>
                                    <Notes onChange={change} changeNot = {changeNotes}/>
                                </div>
                                :
                                <div>
                                    <CheckList onChange={change}/>
                                </div>
                        }
                    </div>
                    :
                    <div>
                        <CheckListCard onChange={change}/>
                        <NotesCard onChange={change} changeNot = {changeNotes}/>
                    </div>
            }
        </div>
    )
}