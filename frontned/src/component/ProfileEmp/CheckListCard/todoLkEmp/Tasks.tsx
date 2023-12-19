import React, {ChangeEvent, useState} from 'react';
import styles from './todo.module.css'
import {ITask} from "../../../../models";
import FormControlLabel from '@mui/material/FormControlLabel';
import {Checkbox} from "@mui/material";
import axios from "axios";

interface TaskProps{
    task: ITask
}

export function Tasks({task}: TaskProps){
    var t = false
    const test = () => {
        task.value.map((item) => (
            t = item.isComplete
        ))
    }

    const [checked, setChecked] = useState(true);

    const handleChange = (e: string) => {
        console.log(e)
        const token = localStorage.getItem('token')
        axios.patch(
            'http://37.139.43.80:80/api/employee/task/'+ e +'/do',
            {},
            {headers: {Authorization: `Bearer ${token}`}}
        )
    }

    return(
        <div className={styles.main}>
            {
                task.value.map(item => (
                    <div>
                        <FormControlLabel
                            control={
                                <Checkbox
                                    checked={item.isComplete}
                                    onChange={() => handleChange(item.id)}
                                    name="checked"
                                    style ={{
                                        color: "#00C996",
                                    }}
                                />
                        }
                            label={<p className={styles.title}>
                                {item.title}
                            </p>}
                        />
                        <p className={styles.text}>{item.desc}</p>
                        <p className={styles.text}> <b>до </b>
                            {
                                ((item.date.split('T'))[0]).split('-')[2]
                            }
                            .
                            {
                                ((item.date.split('T'))[0]).split('-')[1]
                            }
                            .
                            {
                                ((item.date.split('T'))[0]).split('-')[0]
                            }
                        </p>
                    </div>
                ))
            }
        </div>
    )
}

