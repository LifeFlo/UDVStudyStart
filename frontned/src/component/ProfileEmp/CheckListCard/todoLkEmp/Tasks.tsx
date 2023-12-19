import React, {ChangeEvent, useState} from 'react';
import styles from './todo.module.css'
import {ITask} from "../../../../models";
import FormControlLabel from '@mui/material/FormControlLabel';
import {Checkbox} from "@mui/material";

interface TaskProps{
    task: ITask
}

export function Tasks({task}: TaskProps){
    const [checked, setChecked] = React.useState(false);
    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setChecked(event.target.checked);
    };

    return(
        <div className={styles.main}>
            {
                task.value.map(item => (
                    <div>
                        <FormControlLabel
                            control={
                                <Checkbox
                                    checked={checked}
                                    onChange={handleChange}
                                    name="checked"
                                    style ={{
                                        color: "#00C996",
                                    }}
                                />}
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

