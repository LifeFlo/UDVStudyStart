import React, {useRef, useState} from 'react';
import {fakeDatas} from "../data/fakeData";
import type {Scrollbar as BaseScrollbar} from "smooth-scrollbar/scrollbar";
import styles from "../component/modal.module.css";
import {Scrollbar} from "smooth-scrollbar-react";
import {Header} from "../component/headerNoteHr";
import {TodoPanel} from "../component/todoPanel";
import {TodoListHR} from "../component/todoListHR";

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
    const key = 'fio';
    const sorted = fakeDatas.sort((user1, user2) => user1[key] > user2[key] ? 1 : -1);
    const scroller = useRef<BaseScrollbar | null>(null)
    const [value, setValue] = useState('')
    var newar = fakeDatas.map((e) => e.fio)
    const filter = newar.filter(fio => {
        return fio.toLowerCase().includes(value.toLowerCase())
    })

    const [todos, setTodos] = useState(DEFAULT_TODO_LIST)
    const addTodo = ({ name, description }: Omit<Todo, 'id' | 'checked'>) => {
        setTodos([...todos, { id: todos[todos.length - 1].id + 1, description, name, checked: false }]);
    };
    return(
        <div>
            <h1>LK HR</h1>
            <Scrollbar ref = {scroller}>
                <p>Подопечные</p>
                <form>
                    <input
                        type="text"
                        placeholder="Search in the employee"
                        onChange={(event) => setValue(event.target.value)}
                    />
                </form>
                <div className={styles.scrollBar}>
                    {filter.map(item => (
                        <div key={item}>{item}</div>
                    ))}
                </div>
            </Scrollbar>
            <div className={styles.app_container}>
                <div className={styles.container}>
                    <Header todoCount={todos.length}/>
                    <TodoPanel addTodo = {addTodo}/>
                    <TodoListHR todos={todos}/>
                </div>
            </div>
        </div>
    )
}