import React, {useState} from "react";
import styles from './createTodo.module.css'
import {TodoPanel} from "../../../todoHR/todoPanel/todoPanel";
import {Header} from "../../../todoHR/todoHeader/headerNoteHr";
import {TodoListHR} from "../../../todoHR/todoList/todoListHR";
import {ListEmplHr} from "../../../../data/listEmplHr";
import axios from "axios";
import {IEmplHR} from "../../../../models";
import {Task} from "../../../../data/checkListData";
import {styled} from "@mui/material";
import Button from "@mui/material/Button";

const StyledButton = styled(Button)`
  background-color: #00D29D;
  border-radius: 30px;

  font-size: 10px;
  font-family: Montserrat;
  font-weight: 400;
  color: white;
  height: 27px;
  width: 115px;
  box-shadow: 0 3px 5px 2px rgba(131, 201, 183, .3);

  position: absolute;
  top: 92%;
  left: 84%;
  &:hover {
    background-color: #00D29D;
  }
`;

interface EmplHrProps{
    onChange: (e: boolean) => void;
    isActive: (e: boolean) => void;
    choose: string
}

export function CreateTodo( {onChange, isActive, choose} : EmplHrProps){

    const token = localStorage.getItem('token')
    const [data, setData] = useState(ListEmplHr)
    const [check, setCheck] = useState(false)
    const [check2, setCheck2] =useState(false)

    if(!check) {
        axios.get(
            'http://37.139.43.80:80/api/hr/my/employee',
            {headers: {Authorization: `Bearer ${token}`}},
        )
            .then(r => setData(r.data))
        setCheck(true)
    }

    const checkNam = (choose.split(' '))[0];

    const foundEmpl = data.value.find(function (el) {
        return el.name == checkNam
    })

    const id = foundEmpl?.id
    const nameEmp = foundEmpl?.name
    const serEmp = foundEmpl?.surname
    const midlEmpl = foundEmpl?.middleName
    const mailEmpl = foundEmpl?.email

    const [todos, setTodos] = useState(Task)
    const onClickExit = () => {
        window.location.assign('/auth');
    }

    if(!check2) {
        if (id != undefined){
            axios.get(
                'http://37.139.43.80:80/api/hr/employee/' + id + '/tasks',
                {headers: {Authorization: `Bearer ${token}`}},
            )
                .then(r => setTodos(r.data))
            setCheck2(true)
        }
    }

    const onClick = () => {
        onChange(false)
        isActive(false)
    }

    return(
        <div>
            <h1 className={styles.title}>Чек лист</h1>
            <div className={styles.card}>
                <div className={styles.ava}></div>
                <div className={styles.posEmpl}>
                    <p className={styles.fioEmpl}>
                        {nameEmp} {serEmp} {midlEmpl}
                    </p>
                    <p className={styles.mailEmpl}>
                        {mailEmpl}
                    </p>
                </div>
                <Header todoCount={todos.value.length}/>
                <TodoPanel id={id}/>
                <TodoListHR task={todos}/>
                <StyledButton
                    onClick={onClick}
                >
                    Вернуться
                </StyledButton>

            </div>
        </div>
    )
}