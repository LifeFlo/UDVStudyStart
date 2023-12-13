import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import {createBrowserRouter, Navigate, RouterProvider} from "react-router-dom";
import Auth from "./Pages/Auth/Auth";
import Game from "./Pages/Game/Game";
import Profile from "./Pages/Profile/Profile";
import Info from "./Pages/Info/Info";
import {BrowserRouter} from "react-router-dom";
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import Bonus from "./Pages/Bonus";
import Contacts from "./Pages/Contacts";
import Documents from "./Pages/Documents";
import JobWithUniv from "./Pages/JobWithUniv";
import ProfilHR from "./Pages/ProfileHr/ProfilHR";
import Sience from "./Pages/Sience";
import AdaptPeriodPlanet from "./Pages/Game/Planet/AdaptPeriod/AdaptPeriodPlanet";
import BonusPlanet from "./Pages/Game/Planet/Bonus/BonusPlanet";
import FirstDayPlanet from "./Pages/Game/Planet/FirstDay/FirstDayPlanet";
import HolidayPlanet from "./Pages/Game/Planet/Holidays/HolidayPlanet";
import LunchPlanet from "./Pages/Game/Planet/Lunch/LunchPlanet";
import TransportPlanet from "./Pages/Game/Planet/Transport/TransportPlanet";


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
    {
        path: "Bonus",
        element: <Bonus/>
    },
    {
        path: "Contacts",
        element: <Contacts/>
    },
    {
        path: "Documents",
        element: <Documents/>
    },
    {
        path: "JobWithUniv",
        element: <JobWithUniv/>
    },
    {
        path: "ProfilHR",
        element: <ProfilHR/>
    },
    {
        path: "Sience",
        element: <Sience/>
    },
    {
        path: "AdaptPeriodPlanet",
        element: <AdaptPeriodPlanet/>
    },
    {
        path: "BonusPlanet",
        element: <BonusPlanet/>
    },
    {
        path: "FirstDayPlanet",
        element: <FirstDayPlanet/>
    },
    {
        path: "HolidayPlanet",
        element: <HolidayPlanet/>
    },
    {
        path: "LunchPlanet",
        element: <LunchPlanet/>
    },
    {
        path: "TransportPlanet",
        element: <TransportPlanet/>
    },
])


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);


root.render(
      <RouterProvider router={router} />
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals