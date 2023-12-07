import React from 'react';
import { AuthForm } from '../../component/Auth/AuthForm'
import styles from "../../component/Auth/auth.module.css";



export default function Auth() {
    return(
        <div className={styles.auth}>
            <AuthForm />
        </div>
    )
}