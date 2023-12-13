import React, {useState} from 'react';
import styles from "./checkList.module.css";
import Button from '@mui/material/Button';
import {styled} from "@mui/material";

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
    const [check, setCheck] = useState(false)
    return(
        <div>
            <div className={styles.progressCard}>
                <p className={styles.title}>Инструменты</p>
                <div className={styles.card}>
                    <p className={styles.titleCheck}>Чек-лист</p>
                    <span className={styles.text}>Ничего не забудь!)</span>
                    <StyledButton
                        onClick={() => onChange(true)}
                    >
                        Перейти
                    </StyledButton>
                </div>
                <svg
                    width="157" height="157" viewBox="0 0 157 157" fill="none"
                    className={styles.progress}
                >
                    <circle cx="78.5" cy="78.5002" r="64.1389" stroke="#00D29D" stroke-width="20"/>
                    <circle
                        id="progerssBar"
                        className={styles.progressBar}
                        cx="78.5" cy="78.5" r="63.5" stroke="#7E13AB" stroke-width="30"/>
                </svg>
            </div>
        </div>
    )
}