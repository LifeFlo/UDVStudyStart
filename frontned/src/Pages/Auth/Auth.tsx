import React from 'react';
import { AuthForm } from '../../component/Auth/AuthForm'
import styles from "../../component/Auth/auth.module.css";
import axios from "axios";


export default function Auth () {
    return(
        <div>
            <AuthForm/>
        </div>
    )

}

