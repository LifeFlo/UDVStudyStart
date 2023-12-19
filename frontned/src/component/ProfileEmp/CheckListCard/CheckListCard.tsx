import React, {useState} from 'react';
import styles from "./checkList.module.css";
import Button from '@mui/material/Button';
import {styled} from "@mui/material";
import axios from "axios";
import {ProgressBar} from "./ProgressBar";
import {Task} from "../../../data/checkListData";

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
  top: 158px;
  left: 20px;
  &:hover {
    background-color: #00D29D;
  }
`;

// @ts-ignore
export function CheckListCard ( { onChange} ) {
    const token = localStorage.getItem('token')
    const [data, setData] = useState(Task)
    const [check, setCheck] = useState(false)

    if (!check){
        axios.get(
            'http://37.139.43.80:80/api/employee/tasks',
            {headers: {Authorization: `Bearer ${token}`}}
        ).then(x => setData(x.data))
        setCheck(true)
    }

    return(
        <div>
            <div className={styles.progressCard}>
                <p className={styles.title}>Инструменты</p>
                <div className={styles.card}>
                    <p className={styles.titleCheck}>Чек-лист</p>
                    <span className={styles.text}>Ничего не забудь!)</span>
                    <div>
                        <ProgressBar empls={data}/>
                    </div>
                    <StyledButton
                        onClick={() => onChange(true)}
                    >
                        Перейти
                    </StyledButton>
                </div>
            </div>
        </div>
    )
}