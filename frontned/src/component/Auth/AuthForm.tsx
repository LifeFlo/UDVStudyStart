import React, {useEffect} from 'react';
import {useState} from "react";
import Typography from '@mui/material/Typography';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import {useForm, Controller, SubmitHandler, useFormState} from "react-hook-form";
import styles from "../modal.module.css"
import axios from "axios";
import {deflateRaw} from "zlib";

interface ISignInForm{
    login: string;
    password: string;
    mail: string;
}
export const AuthForm = () => {
    const {handleSubmit, control} = useForm<ISignInForm>();
    const { errors } = useFormState({
        control
    })
    const onSubmit: SubmitHandler<ISignInForm> = (data) => console.log('data')

    const [isOpenLog, setIsOpenLog] = useState(false)


    useEffect(()  => {
        axios.post("http://37.139.43.80:80/api/auth", {email: "turnickii.n@gmail.com", password: "123123"})
            .then(() => axios.get("http://37.139.43.80:80/api/account", {withCredentials: true}));
    } )

    const onclick = () => {
        window.location.assign('/profile');
    }

    const onclicks = () =>{
        window.location.assign('/game');
    }

    const onClickHR = () => {
        window.location.assign('/ProfilHR');
    }

    return(
        <div>
            {
                isOpenLog ?
                    <div className={styles.authForm}>
                        <Typography variant="h4" >
                            Создать аккаунт
                        </Typography>
                        <Typography variant="subtitle1" className={styles.authFormSub}>
                            Введите свои данные
                        </Typography>

                        <form className={styles.authFormForm} onSubmit={handleSubmit(onSubmit)}>
                            <Controller
                                control={ control }
                                name="login"
                                rules={{required: 'Заполни'}}
                                render={ ({field}) =>
                                    <TextField
                                        label="Имя"
                                        size="small"
                                        margin="normal"
                                        fullWidth={ true }
                                        onChange={(e) => field.onChange(e)}
                                        value={field.value}
                                        error={ !!errors.login?.message }
                                        helperText={ errors.login?.message }
                                    />
                                }
                            />
                            <Controller
                                control={ control }
                                name = "mail"
                                rules={{required: 'Заполни'}}
                                render={ ({field}) =>
                                    <TextField
                                        label="Почта"
                                        size="small"
                                        margin="normal"
                                        fullWidth={ true }
                                        onChange={(e) => field.onChange(e)}
                                        value={field.value}
                                    />
                                }
                            />
                            <Controller
                                control={ control }
                                name="password"
                                rules={{required: 'Заполни'}}
                                render={ ({field}) =>
                                    <TextField
                                        label="Пароль"
                                        size="small"
                                        margin="normal"
                                        fullWidth={ true }
                                        onChange={(e) => field.onChange(e)}
                                        value={field.value}
                                        error={ !!errors.password?.message }
                                        helperText={ errors.password?.message }
                                    />
                                }
                            />
                        </form>
                        <Button
                            type="submit"
                            variant="contained"
                            fullWidth={ false }
                            disableElevation={ true }
                            sx ={{
                                marginTop: 2
                            }}
                            onClick={onclicks}
                        >
                            Регистрация
                        </Button>
                        <Button
                            type="submit"
                            variant="contained"
                            fullWidth={ false }
                            disableElevation={ true }
                            sx ={{
                                marginTop: 2
                            }}
                            onClick={() => setIsOpenLog(false)}
                        >
                            Вход
                        </Button>
                    </div>
                    :
                    <div className={styles.authForm}>
                        <Typography variant="h4" >
                            Войдите
                        </Typography>
                        <Typography variant="subtitle1" className={styles.authFormSub}>
                            Войдите
                        </Typography>

                        <form className={styles.authFormForm} onSubmit={handleSubmit(onSubmit)}>
                            <Controller
                                control={ control }
                                name="login"
                                rules={{required: 'Заполни'}}
                                render={ ({field}) =>
                                    <TextField
                                        label="Логин"
                                        size="small"
                                        margin="normal"
                                        fullWidth={ true }
                                        onChange={(e) => field.onChange(e)}
                                        value={field.value}
                                        error={ !!errors.login?.message }
                                        helperText={ errors.login?.message }
                                    />
                                }
                            />
                            <Controller
                                control={ control }
                                name="password"
                                rules={{required: 'Заполни'}}
                                render={ ({field}) =>
                                    <TextField
                                        label="Пароль"
                                        size="small"
                                        margin="normal"
                                        fullWidth={ true }
                                        onChange={(e) => field.onChange(e)}
                                        value={field.value}
                                        error={ !!errors.password?.message }
                                        helperText={ errors.password?.message }
                                    />
                                }
                            />
                        </form>
                        <Button
                            type="submit"
                            variant="contained"
                            fullWidth={ false }
                            disableElevation={ true }
                            sx ={{
                                marginTop: 2
                            }}
                            onClick={onclick}
                        >
                            Войти
                        </Button>
                        <Button
                            type="submit"
                            variant="contained"
                            fullWidth={ false }
                            disableElevation={ true }
                            sx ={{
                                marginTop: 2
                            }}
                            onClick={() => setIsOpenLog(true)}
                        >
                            Регистрация
                        </Button>
                        <Button
                            type="submit"
                            variant="contained"
                            fullWidth={ false }
                            disableElevation={ true }
                            sx ={{
                                marginTop: 2
                            }}
                            onClick={onClickHR}
                        >
                            Войти для Эйчара
                        </Button>
                    </div>
            }
        </div>
    )
}