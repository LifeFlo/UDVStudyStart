import React from 'react';
import {useState} from "react";
import Typography from '@mui/material/Typography';
import TextField from '@mui/material/TextField';
import {useForm, Controller, SubmitHandler, useFormState} from "react-hook-form";
import styles from "../Auth/auth.module.css"
import axios from "axios";
import { redirect } from "react-router"
import {Navigate} from "react-router-dom";

interface ISignInForm{
    password: string;
    mail: string;
}
// @ts-ignore
export const AuthForm = ( ) => {
    const {handleSubmit, control} = useForm<ISignInForm>();
    const { errors } = useFormState({
        control
    })
    const [password, passwordValue] = useState('')
    const [mail, mailValue] = useState('')

    const request = async (mail: string, password: string) => {
        axios.post('http://37.139.43.80:80/api/auth',
            {email: mail, password: password})
            .then(x => checkToken(x.data.value))
        }

    const checkToken = (check: string) => {
        if (check === null) {
            console.log('not')
        }
        else {
            console.log(check)
            localStorage.setItem('token',check)
            //
            axios.get(
                'http://37.139.43.80:80/api/account',
                {headers: {Authorization: `Bearer ${check}`}},
            )
                .then(r => checkRole(r.data.value.role))
        }
    }

    const checkRole = (role: string) => {
        if (role === 'Employee'){
            window.location.assign('/profile');
        }
        else {
            window.location.assign('/ProfilHR');
        }
    }

    return(
        <div className={styles.auth}>
            <div className={styles.fon}>
                <div className={styles.authForm}>
                    <p className={styles.titulEnter}>
                        Войти в аккаунт
                    </p>
                    <form className={styles.form}>
                        <Controller
                            control={ control }
                            name="mail"
                            rules={{required: 'Заполни'}}
                            render={ ({field}) =>
                                <TextField
                                    variant="standard"
                                    label="Логин"
                                    onChange={(e) => mailValue(e.target.value)}
                                    value={field.value }
                                    className={styles.textField}
                                />
                            }
                        />
                        <Controller
                            control={ control }
                            name="password"
                            rules={{required: 'Заполни'}}
                            render={ ({field}) =>
                                <TextField
                                    variant="standard"
                                    label="Пароль"
                                    onChange={(e) => passwordValue(e.target.value)}
                                    value={field.value}
                                    className={styles.textField}
                                />
                            }
                        />
                    </form>
                    <div>
                        <button
                            className={styles.btnEnter}
                            onClick={() => request(mail, password)}
                        >
                            Войти
                        </button>
                    </div>
                </div>
            </div>
        </div>
    )
}