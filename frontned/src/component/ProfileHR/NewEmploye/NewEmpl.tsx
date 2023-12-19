import React, {useState} from "react";
import styles from './newEmpl.module.css'
import {Controller, useForm, useFormState} from "react-hook-form";
import TextField from "@mui/material/TextField";
import {styled, ThemeProvider} from "@mui/material";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import {createTheme} from "@mui/material/styles";
import {teal} from "@mui/material/colors";
import axios from "axios";

const StyledButtons = styled(Button)`
  background-color: #00D29D;
  border-radius: 7px;
  width: 30px;
  box-shadow: 0 3px 5px 2px rgba(131, 201, 183, .3);

  position: absolute;
  left: 29.8%;
  top: 58%;

  &:hover {
    background-color: #00D29D;
  }
`;

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
  left: 35.5%;
  top: 92%;

  &:hover {
    background-color: #00D29D;
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

interface INewEmpl{
    name: string,
    surname: string,
    middleName: string,
    email: string
}

// @ts-ignore
export function NewEmpl( {onChange} ){
    const {handleSubmit, control} = useForm<INewEmpl>();
    const { errors } = useFormState({
        control
    })

    const [name, nameValue] = useState('')
    const [surname, surnameValue] = useState('')
    const [middleName, middleNameValue] = useState('')
    const [email, emailValue] = useState('')
    const token = localStorage.getItem('token')
    let nam = name
    let sur = surname
    let midl = middleName
    let mail = email

    const onClick = (nam: string, sur: string, midl: string, mail: string) =>{
        axios.post(
           'http://37.139.43.80:80/api/hr/create/employee',
            {name: nam, surname: sur, middleName: midl, email: mail},
            {headers: {Authorization: `Bearer ${token}`}}
        ).then(x => console.log(x.data))

    }

    return(
        <div className={styles.pos}>
            <h1 className={styles.title}>Создание нового сотрудника</h1>
            <div className={styles.card}>
                <form className={styles.form}>
                    <div className={styles.fild}>
                        <Controller
                            control={ control }
                            name="name"
                            rules={{required: 'Заполни'}}
                            render={ ({field}) =>
                                <TextField
                                    variant="standard"
                                    label="Имя"
                                    onChange={(e) => nameValue(e.target.value)}
                                    value={field.value }
                                    className={styles.textField}
                                />
                            }
                        />
                    </div>
                    <div className={styles.fild}>
                        <Controller
                            control={ control }
                            name="surname"
                            rules={{required: 'Заполни'}}
                            render={ ({field}) =>
                                <TextField
                                    variant="standard"
                                    label="Фамилия"
                                    onChange={(e) => surnameValue(e.target.value)}
                                    value={field.value}
                                    className={styles.textField}
                                />
                            }
                        />
                    </div>
                    <div className={styles.fild}>
                        <Controller
                            control={ control }
                            name="middleName"
                            rules={{required: 'Заполни'}}
                            render={ ({field}) =>
                                <TextField
                                    variant="standard"
                                    label="Отчество"
                                    onChange={(e) => middleNameValue(e.target.value)}
                                    value={field.value}
                                    className={styles.textField}
                                />
                            }
                        />
                    </div>
                    <div className={styles.fild}>
                        <Controller
                            control={ control }
                            name="email"
                            rules={{required: 'Заполни'}}
                            render={ ({field}) =>
                                <TextField
                                    variant="standard"
                                    label="Почта"
                                    onChange={(e) => emailValue(e.target.value)}
                                    value={field.value}
                                    className={styles.textField}
                                />
                            }
                        />
                    </div>
                </form>
                <StyledButtons
                    onClick={() => onClick(nam, sur, midl, mail)}
                >
                    <ThemeProvider theme={theme}>
                        <AddIcon color='primary' fontSize='medium'/>
                    </ThemeProvider>
                </StyledButtons>
                <StyledButton
                    onClick={() => onChange(false)}
                >
                    Вернуться
                </StyledButton>
            </div>
        </div>
    )
}