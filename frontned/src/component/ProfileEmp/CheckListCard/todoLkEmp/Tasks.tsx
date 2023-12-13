import React, {useState} from 'react';
import styles from './todo.module.css'
import {ITask} from "../../../../models";
import FormControlLabel from '@mui/material/FormControlLabel';
import {Checkbox} from "@mui/material";

interface TaskProps{
    task: ITask
}

export function Tasks({task}: TaskProps){
    return(
        <div className={styles.main}>
            <FormControlLabel
                control={
                <Checkbox
                    name="checkedC"
                    style ={{
                        color: "#00C996",
                    }}
                />}
                label={<p className={styles.title}>{task.title}</p>} />
            <p className={styles.text}>{task.discription}</p>
        </div>
    )
}

