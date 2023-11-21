import React from 'react';
import styles from "./modal.module.css";
import {TodoItem} from "./todoItem";

interface TodoListProps {
    todos: Todo[];
}

export const TodoListHR: React.FC<TodoListProps> = ( {todos} ) => (
    <div>
        {todos.map(todo => (
            <TodoItem todo={todo}/>
        ))}
    </div>
)
