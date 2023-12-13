import React from "react";
import styles from "./notesCardHr.module.css"
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
export function NotesCardHr( ){
    return(
        <div>
            <p className={styles.title}>Заметки</p>
            <div className={styles.card}>
                <p className={styles.titleNot}>Заметки</p>
                <span className={styles.text}>Что-то важное? Запиши, чтобы не забыть!</span>
                <StyledButton
                >
                    Перейти
                </StyledButton>
            </div>
            <div className={styles.notesList}>
                <p className={styles.notesListTitle}>Ваши заметки</p>
            </div>
        </div>
    )
}