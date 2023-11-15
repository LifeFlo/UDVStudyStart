import React from "react";
import {Product} from "../../component/AboutMainComp";
import {products} from "../../data/aboutMain";

export default function Info() {
    return(
        <div>
            <h1>Удиви <br />МИР!</h1>
            <p> Коротко о главном</p>
            <Product product = {products[0]}/>
            <Product product = {products[1]}/>
            <Product product = {products[2]}/>
            <Product product = {products[3]}/>
        </div>
    )
}