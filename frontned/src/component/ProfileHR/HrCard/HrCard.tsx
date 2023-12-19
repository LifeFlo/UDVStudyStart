import React, {useState} from "react";
import styles from './hrCard.module.css'
import Button from '@mui/material/Button';
import {styled, ThemeProvider} from "@mui/material";
import axios from "axios";
import EditNoteIcon from '@mui/icons-material/EditNote';
import PeopleAltIcon from '@mui/icons-material/PeopleAlt';
import {createTheme} from "@mui/material/styles";
import {grey, purple, teal} from "@mui/material/colors";

const StyledButton = styled(Button)`
  text-transform: Capitalize;
  border-radius: 30px;
  font-size: 14px;
  font-family: Montserrat;
  font-weight: 425;
  color: #1E1E1E;
  position: absolute;
  left: 10%;
  top: 40%;

  //&:hover {
  //  background-color: #E1C8EB;
  //  border-radius: 30px;
  //}
`;
const StyledButtons = styled(Button)`
  text-transform: Capitalize;
  border-radius: 30px;
  font-size: 14px;
  font-family: Montserrat;
  font-weight: 425;
  color: #1E1E1E;
  position: absolute;
  top: 47%;

  //&:hover {
  //  background-color: #00D29D;
  //}
`;

const theme = createTheme({
    palette: {
        primary: {
            main: '#00D29D',
        },
        secondary: {
            main: '#f44336',
        },
    },
});
// @ts-ignore
export function HrCard( {onChange, changeNewEmpl} ) {
    const [name, setName] = useState()
    const [surname, setSurname] = useState()
    const [midl, setMidl] = useState()

    const token = localStorage.getItem('token')
    axios.get(
        'http://37.139.43.80:80/api/account',
        {headers: {Authorization: `Bearer ${token}`}},
    )
        .then(r => setName(r.data.value.name))
    axios.get(
        'http://37.139.43.80:80/api/account',
        {headers: {Authorization: `Bearer ${token}`}},
    )
        .then(r => setSurname(r.data.value.surname))
    axios.get(
        'http://37.139.43.80:80/api/account',
        {headers: {Authorization: `Bearer ${token}`}},
    )
        .then(r => setMidl(r.data.value.middleName))

    let nam = name
    let ser = surname
    let mid = midl
    const onClickExit = () => {
        window.localStorage.removeItem('token')
        window.location.assign('/auth');
    }

    return(
        <div className={styles.card}>
            <div className={styles.ava}></div>
            <div className={styles.fio}>
                {nam} <span> {ser}</span> <span>{mid}</span>
            </div>
            <StyledButton
                onClick={() => onChange(true)}
            >
                <ThemeProvider theme={theme}>
                    <EditNoteIcon color='primary' fontSize='medium'/>
                    <p className={styles.test1}>Чек-лист</p>
                </ThemeProvider>
            </StyledButton>

            <StyledButtons
                onClick={() => changeNewEmpl(true)}
            >
                <ThemeProvider theme={theme}>
                    <PeopleAltIcon color='primary' fontSize='medium'/>
                    <p className={styles.test}>Добавить сотрудника</p>
                </ThemeProvider>
            </StyledButtons>

            <button
                className={styles.btnExit}
                onClick={() => onClickExit()}>
                Выход
            </button>
        </div>
    )
}