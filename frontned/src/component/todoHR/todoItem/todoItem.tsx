import React, {useRef} from 'react';
import {Scrollbar} from "smooth-scrollbar-react";
import styles from "../toDo.module.css";
import {ITask} from "../../../models";
import {Scrollbar as BaseScrollbar} from "smooth-scrollbar/scrollbar";

interface TaskProps{
    task: ITask
}

export function TodoItem  ( {task}: TaskProps ) {
    const scroller = useRef<BaseScrollbar | null>(null)
    return(
        <div>
            {task.value.map(todo => (
                <div className={styles.cardTask}>
                    <p className={styles.title}>{todo.title}</p>
                    <p className={styles.text}>{todo.desc}</p>
                </div>
            ))}
        </div>
    )
}