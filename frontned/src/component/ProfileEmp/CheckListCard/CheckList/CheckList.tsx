import React, {useRef, useState} from 'react';
import styles from "./check.module.css"
import {Tasks} from "../todoLkEmp/Tasks";
import {ITask} from "../../../../models";
import {Task} from "../../../../data/checkListData";
import Button from '@mui/material/Button';
import {styled} from "@mui/material";
import {Scrollbar} from "smooth-scrollbar-react";
import type {Scrollbar as BaseScrollbar} from "smooth-scrollbar/scrollbar";
import axios from "axios";

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
  top: 233px;
  left: 620px;
  &:hover {
    background-color: #00D29D;
  }
`;
// @ts-ignore
export function CheckList ( { onChange} ) {
    const token = localStorage.getItem('token')
    const [data, setData] = useState(Task)
    const [check, setCheck] = useState(false)
    if (!check){
        axios.get(
            'http://37.139.43.80:80/api/employee/tasks',
            {headers: {Authorization: `Bearer ${token}`}},
        )
            .then(r => setData(r.data))
        setCheck(true)
    }



    const scroller = useRef<BaseScrollbar | null>(null)
    return(
        <div>
            <p className={styles.title}> Чек-лист </p>
            <div className={styles.card}>
                <Scrollbar ref = {scroller}>
                    <div className={styles.scrollBar}>
                        <Tasks task={data}/>
                    </div>
                </Scrollbar>
                <StyledButton
                    onClick={() => onChange(false)}
                >
                    Вернуться
                </StyledButton>
            </div>
        </div>

    )
}