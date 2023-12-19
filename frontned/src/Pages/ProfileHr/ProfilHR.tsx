import React, {useRef, useState} from 'react';
import styles from "./profelHr.module.css"
import {EmplHrCard} from "../../component/ProfileHR/EmployeCard/EmplHrCard";
import {HrCard} from "../../component/ProfileHR/HrCard/HrCard";
import {NotesCardHr} from "../../component/ProfileHR/NotesCard/NotesCardHr";
import {NavigationForLK} from "../../component/Navigation/NavigationLkEmp/NavigationForLK";
import {ChooseEmpl} from "../../component/ProfileHR/CheckListHR/ChooseEmpl/ChooseEmpl";
import {CreateTodo} from "../../component/ProfileHR/CheckListHR/CreateCheck/CreateTodo";
import {NewEmpl} from "../../component/ProfileHR/NewEmploye/NewEmpl";


export default function ProfilHR(){
    const [check, setCheck] = useState(false)
    const change = (value: boolean | ((prevState: boolean) => boolean)) => {
        setCheck(value)
    }

    const [isCheckTodoActive, setCheckTodoActive] = useState(false)
    const changeTodo = (value: boolean | ((prevState: boolean) => boolean)) => {
        setCheckTodoActive(value)
    }

    const [chooseEm, setChooseEm] = useState('')
    const chooseEmploye = (e: React.SetStateAction<string>) => {
        setChooseEm(e)
    }

    const [checkNewEmpl, setCheckNewEmpl] = useState(false)
    const changeNewEmpl = (e: boolean | ((prevState: boolean) => boolean)) =>{
        setCheckNewEmpl(e)
    }

    return(
        <div className={styles.background}>
            <NavigationForLK />
            <HrCard onChange={change} changeNewEmpl={changeNewEmpl}/>
            {
                check?
                    <div>
                        {
                            isCheckTodoActive ?
                                <div>
                                    <CreateTodo onChange={change} isActive={changeTodo} choose={chooseEm}/>
                                </div>
                                :
                                <div>
                                    <ChooseEmpl onChange={changeTodo} choose={chooseEmploye}/>
                                </div>
                        }
                    </div>
                    :
                    <div>
                        {
                            checkNewEmpl?
                                <div>
                                    <NewEmpl onChange={changeNewEmpl}/>
                                </div>
                                :
                                <div>
                                    <EmplHrCard/>
                                    <NotesCardHr/>
                                </div>
                        }
                    </div>
            }
        </div>
    )
}