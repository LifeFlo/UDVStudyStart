import React, {useRef, useState} from 'react';
import styles from "./profelHr.module.css"
import {EmplHrCard} from "../../component/ProfileHR/EmployeCard/EmplHrCard";
import {HrCard} from "../../component/ProfileHR/HrCard/HrCard";
import {NotesCardHr} from "../../component/ProfileHR/NotesCard/NotesCardHr";
import {Header} from "../../component/todoHR/todoHeader/headerNoteHr";
import {TodoPanel} from "../../component/todoHR/todoPanel/todoPanel";
import {TodoListHR} from "../../component/todoHR/todoList/todoListHR";
import {NavigationForLK} from "../../component/Navigation/NavigationLkEmp/NavigationForLK";

const DEFAULT_TODO_LIST = [
    { id: 1, name: 'task 1', description: 'description 1', checked: false },
    { id: 2, name: 'task 2', description: 'description 2', checked: false },
    {
        id: 3,
        name: 'task 3',
        description:
            'so long task description 3 so long task description so long task description so long task description so long task description',
        checked: true
    }
];

export default function ProfilHR(){
    const [todos, setTodos] = useState(DEFAULT_TODO_LIST)
    const addTodo = ({ name, description }: Omit<Todo, 'id' | 'checked'>) => {
        setTodos([...todos, { id: todos[todos.length - 1].id + 1, description, name, checked: false }]);
    };
    return(
        <div className={styles.background}>
            <NavigationForLK />
            <HrCard/>
            <EmplHrCard/>
            <NotesCardHr/>
            {/*<div>*/}
            {/*    <div>*/}
            {/*        <Header todoCount={todos.length}/>*/}
            {/*        <TodoPanel addTodo = {addTodo}/>*/}
            {/*        <TodoListHR todos={todos}/>*/}
            {/*    </div>*/}
            {/*</div>*/}
        </div>
    )
}