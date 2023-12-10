import React from "react";
import {Product} from "../../component/MainPage/AboutMainComp";
import {products} from "../../data/aboutMain";

import Game from "../Game/Game";
import {Route, Routes} from 'react-router-dom'
import {NavigationsForMainPage} from "../../component/Navigation/NavigationMainPage/NavigationsForMainPage";

export default function Info() {
    return(
        <div>
            {/*<>*/}
            {/*    <NavigationsForMainPage />*/}
            {/*    <Routes>*/}
            {/*        <Route path ="/profile" element={ <Profile />}/>*/}
            {/*        <Route path ="/about" element={ <Game />}/>*/}
            {/*    </Routes>*/}
            {/*</>*/}
            <h1>Удиви <br />МИР!</h1>
            <p> Коротко о главном</p>
            <Product product = {products[0]}/>
            <Product product = {products[1]}/>
            <Product product = {products[2]}/>
            <Product product = {products[3]}/>
        </div>
    )
}