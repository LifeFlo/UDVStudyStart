import React, {useState} from "react"
import {IProduct} from "../models"

interface ProductProps{
    product: IProduct
}

export function Product({product}: ProductProps){
    const [details, setDetails] = useState(false)
    return (
        <div>
            <p>{product.title}</p>
            <button
                onClick={() => setDetails(prev => !prev)}
            >
                Show Discription
            </button>

            {details && <div>
                <p> {product.discription}</p>
            </div>}
        </div>
    )
}
