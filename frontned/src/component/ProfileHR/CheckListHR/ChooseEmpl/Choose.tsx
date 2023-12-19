import React, {useState} from 'react';
import styles from './choose.module.css'
import {IEmplHR} from "../../../../models";
import {styled} from "@mui/material";
import Button from "@mui/material/Button";
import {ProgressBar} from "../../EmployeCard/ProgressBar";


interface EmplHrProps{
    empls: IEmplHR
    value: string
    setItem: (e: string) => void;
}

const StyledButton = styled(Button)`
  text-transform: capitalize;
  color: #000;
  font-family: Montserrat;
  font-size: 15px;
  font-weight: 400;
  margin-top: 20px;
  margin-left: 20px;
  border: 0;
  background: transparent;
  &:hover {
    background-color: #DEF1EC;
  }
`;

export function Choose({empls, value, setItem} : EmplHrProps){
    var listEmplHr = empls.value.map(item =>(
        item.name + ' ' + item.surname + ' ' + item.middleName
    ))
    const filter = listEmplHr.filter(fio => {
        return fio.toLowerCase().includes(value.toLowerCase())
    })

    // console.log((item.split(' '))[0])
    return(
        <div>
            {
                filter.map(item => (
                    <StyledButton
                        key={item}
                        onClick={() => setItem(item)}
                    >
                        <p className={styles.emp}>{item}</p>
                        <ProgressBar empls={empls} name={item}/>
                    </StyledButton>
                ))
            }
        </div>
    )
}