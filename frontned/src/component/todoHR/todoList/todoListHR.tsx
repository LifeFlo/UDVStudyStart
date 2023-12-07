import React from 'react';
import {TodoItem} from "../todoItem/todoItem";

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
