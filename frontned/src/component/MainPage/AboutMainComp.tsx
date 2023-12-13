import React, {useState} from "react"
import {IProduct} from "../../models"
import AddIcon from '@mui/icons-material/Add';
import IconButton from '@mui/material/IconButton';
import styles from './mainCom.module.css'
import { createTheme } from '@mui/material/styles';
import { teal} from '@mui/material/colors';
import {ThemeProvider} from "@mui/material";
import {styled} from "@mui/material";

const StyledButton = styled(IconButton)`
  &:hover {
    background-color: #00A77D;
  }
`;
interface ProductProps{
    product: IProduct
}

const theme = createTheme({
    palette: {
        primary: {
            main: teal[50],
        },
        secondary: {
            main: '#f44336',
        },
    },
});

export function Product({product}: ProductProps){
    const [details, setDetails] = useState(false)
    return (
        <div className={styles.main}>
            <div className={styles.btnAdd}>
                <StyledButton
                    onClick={() => setDetails(prev => !prev)}
                >
                    <ThemeProvider theme={theme}>
                        <AddIcon color='primary' fontSize='large'/>
                    </ThemeProvider>
                </StyledButton>
            </div>
            <p className={styles.title}>{product.title}</p>
            {details && <div>
                <p className={styles.discription}> {product.discription}</p>
            </div>}
        </div>
    )
}
