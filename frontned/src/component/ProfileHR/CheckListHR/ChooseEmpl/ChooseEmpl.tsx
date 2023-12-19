import React, {useRef, useState} from "react";
import styles from './choose.module.css'
import {Scrollbar} from "smooth-scrollbar-react";
import {ListEmplHr} from "../../../../data/listEmplHr";
import {Scrollbar as BaseScrollbar} from "smooth-scrollbar/scrollbar";
import Button from '@mui/material/Button';
import {styled} from "@mui/material";
import axios from "axios";
import {Choose} from "./Choose";

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
  margin-top: 45px;

  position: absolute;
  top: 100%;

  &:hover {
    background-color: #00D29D;
  }
`;

// @ts-ignore
export function ChooseEmpl( {onChange, choose} ){
    const token = localStorage.getItem('token')
    const [data, setData] = useState(ListEmplHr)
    const [check, setCheck] = useState(false)

    if(!check) {
        axios.get(
            'http://37.139.43.80:80/api/hr/my/employee',
            {headers: {Authorization: `Bearer ${token}`}},
        )
            .then(r => setData(r.data))
        setCheck(true)
    }

    const scroller = useRef<BaseScrollbar | null>(null)
    const [item, setItem ] = useState('')
    const [value, setValue] = useState('')
    const chooseEmpl = (e: string) =>{
        setItem(e)
    }

    choose(item)

    return(
        <div className={styles.pos}>
            <Scrollbar ref = {scroller}>
                <p className={styles.title}>Сотрудники</p>
                <form>
                    <input
                        className={styles.search}
                        type="text"
                        placeholder="Поиск"
                        onChange={(event) => setValue(event.target.value)}
                    />
                </form>
                <div className={styles.scrollBar}>
                    <Choose empls={data} value = {value} setItem={chooseEmpl}/>
                </div>
            </Scrollbar>
            <StyledButton
                onClick={() => onChange(true)}
            >
                Дальше
            </StyledButton>
        </div>
    )
}