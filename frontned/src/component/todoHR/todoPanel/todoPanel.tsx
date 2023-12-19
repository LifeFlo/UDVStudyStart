import React, {useState} from "react";
import styles from "../toDo.module.css"
import Button from "@mui/material/Button";
import axios from "axios";
import AddIcon from "@mui/icons-material/Add";
import {styled, ThemeProvider} from "@mui/material";
import {createTheme} from "@mui/material/styles";
import {teal} from "@mui/material/colors";

const StyledButton = styled(Button)`
  background-color: #00D29D;
  position: absolute;
  top:38%;
  left: 66%;
  

  &:hover {
    background-color: #84D9C3;
  }
`;

const theme = createTheme({
    palette: {
        primary: {
            main: teal[50],
        },
        secondary: {
            main: '#f44336',
        },
    },
});

interface TodoPanelProps {
    id: string | undefined
}
export function TodoPanel ({id} : TodoPanelProps) {
    const [valueName, setValueName] = useState('')
    const [valueDisc, setValueDisc] = useState('')
    const deadline = '2024-01-23T15:03:39.009Z'
    const idEmpl = id
    const token = localStorage.getItem('token')

    const onClick = (id: string | undefined, titl: string, descr: string, data: string) => {
        axios.post(
            'http://37.139.43.80:80/api/hr/task/create',
            {accountId: id, title: titl, desc: descr, date: data},
            {headers: {Authorization: `Bearer ${token}`}}
        )
            .then(x => console.log(x.data))
    }

    return(
        <div className={styles.todo_panel_container}>
            <div className={styles.fields_container}>
                <div className={styles.field_container}>
                    <label htmlFor="Название">
                        <div>Название</div>
                        <input
                            type="text"
                            id ='Название'
                            name='Название'
                            onChange={(event) => setValueName(event.target.value)}
                        />
                    </label>
                </div>
                <div className={styles.field_container}>
                    <label htmlFor="discription">
                        <div>Описание</div>
                        <input
                            type="text"
                            id ='discription'
                            name='discription'
                            onChange={(event) => setValueDisc(event.target.value)}
                        />
                    </label>
                </div>

            </div>
            <div className={styles.fields_container}>
                <div className={styles.date_container}>
                    <label htmlFor="discription">
                        <div>Дедлайн</div>
                        <input
                            type="text"
                            id ='discription'
                            name='discription'
                            onChange={(event) => setValueDisc(event.target.value)}
                        />
                    </label>
                </div>
            </div>
            <div className={styles.button_container}>
                <StyledButton
                    onClick={() => onClick(idEmpl, valueName, valueDisc, deadline)}
                >
                    <ThemeProvider theme={theme}>
                        <AddIcon color='primary' fontSize='large'/>
                    </ThemeProvider>
                </StyledButton>
            </div>
        </div>
    )
}