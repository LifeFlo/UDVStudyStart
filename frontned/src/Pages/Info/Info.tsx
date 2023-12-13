import React from "react";
import {Product} from "../../component/MainPage/AboutMainComp";
import {products} from "../../data/aboutMain";
import {Route, Routes} from 'react-router-dom'
import styles from "./info.module.css";
import {NavigationsForMainPage} from "../../component/Navigation/NavigationMainPage/NavigationsForMainPage";

export default function Info() {
    return(
        <div className={styles.background}>
            <NavigationsForMainPage />
            <Routes>
                <Route path ="/info" element={ <Info />}/>
                <Route path ="/about" element={ <Info />}/>
                <Route path ="/about" element={ <Info />}/>
                <Route path ="/about" element={ <Info />}/>
                <Route path ="/about" element={ <Info />}/>
                <Route path ="/about" element={ <Info />}/>
                <Route path ="/about" element={ <Info />}/>
            </Routes>
            <div className={styles.cosmos}></div>
            <h1 className={styles.mainTitle}>Добро пожаловать <br />в нашу команду!</h1>
            <div className={styles.title}>
                <p className={styles.textTitle}> Коротко о главном</p>
            </div>
            <Product product = {products[0]}/>
            <Product product = {products[1]}/>
            <Product product = {products[2]}/>
            <Product product = {products[3]}/>
            <div>h</div>
        </div>
    )
}