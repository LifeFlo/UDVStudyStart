import React from "react";
import styles from "./adaptCard.module.css"
import axios from "axios";
import Button from '@mui/material/Button';
import {styled} from "@mui/material";

const StyledButton = styled(Button)`
  background-color: #7E13AB;
  border-radius: 30px;

  font-size: 10px;
  font-family: Montserrat;
  font-weight: 400;
  color: white;
  height: 27px;
  width: 115px;
  box-shadow: 0 3px 5px 2px rgba(164, 124,181, .3);

  position: absolute;
  top: 143px;
  left: 411px;
  &:hover {
    background-color: #7E13AB;
  }
`;
export function AdaptCard(){
    return(
        <div>
            <p className={styles.title}>Адаптационный период</p>
            <div className={styles.card}>
                <p className={styles.titleNast}>Личный наставник</p>
                <p className={styles.fioNast}>Рыков Владимир Иванович</p>
                <div className={styles.infNast}>
                    <li className={styles.listEl}>Телефон</li>
                    <li className={styles.listEl}>Почта</li>
                    <li>Телеграмм</li>
                </div>
                <div className={styles.dateCard}>
                    <p className={styles.dateText}>Даты</p>
                </div>
                <p className={styles.gameText}>Пройди <span className={styles.mark}>увлекательную</span> новеллу,
                    чтобы быстрее ознакомиться с адаптационным периодом!</p>
                <StyledButton
                onClick={() => window.location.assign('/game')}>
                    Играть
                </StyledButton>
            </div>
        </div>
    )
}