import React, {useRef} from 'react';
import {TodoItem} from "../todoItem/todoItem";
import styles from '../toDo.module.css'
import {ITask} from "../../../models";
import {Tasks} from "../../ProfileEmp/CheckListCard/todoLkEmp/Tasks";
import {Scrollbar} from "smooth-scrollbar-react";
import type {Scrollbar as BaseScrollbar} from "smooth-scrollbar/scrollbar";

interface TaskProps{
    task: ITask
}

export function TodoListHR  ( {task}: TaskProps ) {
    const scroller = useRef<BaseScrollbar | null>(null)
    return(
        <div>
            <Scrollbar ref = {scroller}>
                <div className={styles.scrollBar}>
                    <TodoItem task={task}/>
                </div>
            </Scrollbar>
        </div>
        )
}
