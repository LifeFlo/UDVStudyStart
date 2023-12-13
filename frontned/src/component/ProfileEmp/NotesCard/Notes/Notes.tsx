import React from "react";
import Button from '@mui/material/Button';
import {styled} from "@mui/material";

const StyledButton = styled(Button)`
  background-color: #00D29D;
  border-radius: 30px;

  font-size: 10px;
  font-family: Montserrat;
  font-weight: 400;
  color: white;
  height: 27px;
  width: 115px;
  box-shadow: 0 3px 5px 2px rgba(131, 201, 183, .3);

  position: absolute;
  top: 158px;
  left: 20px;
  &:hover {
    background-color: #00D29D;
  }
`;
// @ts-ignore
export function Notes( {onChange, changeNot} ){
    const helper = () => {
        onChange(false)
        changeNot(false)
    }
    return(
        <div>
            <StyledButton
                onClick={helper}
            >
                Come Back
            </StyledButton>
        </div>

    )
}