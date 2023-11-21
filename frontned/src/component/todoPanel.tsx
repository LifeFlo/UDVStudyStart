import React, {ChangeEvent, useState} from "react";
import styles from "../component/modal.module.css"
import Button from "@mui/material/Button";

const Defoult_todo ={
    name: '',
    discription: ''
}

interface TodoPanelProps {
    addTodo: ({ name, description }: Omit<Todo, 'id' | 'checked'>) => void

}


export const TodoPanel: React.FC<TodoPanelProps> = ({ addTodo }) => {
    const [todo, setTodo] = useState(Defoult_todo)

    const onChange =(event: React.ChangeEvent<HTMLInputElement>) => {
        const{name, value} = event.target;
        setTodo({ ...todo, [name]: value});
    };

    const onClick = () => {
        addTodo({name: todo.name, description: todo.discription})
        setTodo(Defoult_todo);
    };
    return(
        <div className={styles.todo_panel_container}>
            <div className={styles.fields_container}>
                <div className={styles.field_container}>
                    <label htmlFor="name">
                        <div>name</div>
                        <input type="text" id ='name' value ={todo.name} name='name' onChange={onChange}/>
                    </label>
                </div>
                <div className={styles.field_container}>
                    <label htmlFor="discription">
                        <div>discription</div>
                        <input type="text" id ='discription' value ={todo.discription} name='discription' onChange={onChange}/>
                    </label>
                </div>
            </div>
            <div className={styles.button_container}>
                <Button onClick={onClick}> ADD</Button>
            </div>
        </div>
    )
}