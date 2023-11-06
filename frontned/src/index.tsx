import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import {createBrowserRouter, Navigate, RouterProvider} from "react-router-dom";
import Auth from "./Pages/Auth/Auth";
import Game from "./Pages/Game/Game";
import Profile from "./Pages/Profile/Profile";
import Info from "./Pages/Info/Info";

const router = createBrowserRouter([
    {
        path: "*",
        element: <div> <Navigate to={"auth"}/> </div>
    },
    {
        path: "auth",
        element: <Auth/>
    },
    {
        path: "game",
        element: <Game/>
    },
    {
        path: "Profile",
        element: <Profile/>
    },
    {
        path: "Info",
        element: <Info/>
    },
])


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  <React.StrictMode>
      <RouterProvider router={router} />
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals