import React, {useState} from 'react';
import {ITask} from "../models";

interface TaskProps{
    task: ITask
}

export function Tasks({task}: TaskProps){
    const [doneTask, setDoneTask] = useState()

    return(
        <div>
            <li>
                <input type="checkbox" />
                {task.discription}
            </li>
        </div>
    )
}

