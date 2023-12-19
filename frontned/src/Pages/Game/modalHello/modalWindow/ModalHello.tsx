import React, { useCallback, useEffect, useRef, useState } from "react";
import type { MouseEventHandler } from "react";
import FastForwardOutlinedIcon from '@mui/icons-material/FastForwardOutlined';
import IconButton from '@mui/material/IconButton';
import { createTheme } from '@mui/material/styles';
import { teal} from '@mui/material/colors';
import {ThemeProvider} from "@mui/material";
import Portal, { createContainer } from "../portal";
import Styles from "./modalHello.module.css";
import AddIcon from "@mui/icons-material/Add";

const theme = createTheme({
    palette: {
        primary: {
            main: teal[300],
        },
        secondary: {
            main: '#f44336',
        },
    },
});

const MODAL_CONTAINER_ID = "modal-container-id";
type Props = {
    title: string;
    onClose?: () => void;
    children: React.ReactNode | React.ReactNode[];
};

const ModalHello = (props: Props) => {
    const { title, onClose, children } = props;

    const rootRef = useRef<HTMLDivElement>(null);
    const [isMounted, setMounted] = useState(false);

    useEffect(() => {
        createContainer({ id: MODAL_CONTAINER_ID });
        setMounted(true);
    }, []);

    useEffect(() => {
        const handleWrapperClick = (event: MouseEvent) => {
            const { target } = event;

            if (target instanceof Node && rootRef.current === target) {
                onClose?.();
            }
        };
        const handleEscapePress = (event: KeyboardEvent) => {
            if (event.key === "Escape") {
                onClose?.();
            }
        };

        window.addEventListener("click", handleWrapperClick);
        window.addEventListener("keydown", handleEscapePress);

        return () => {
            window.removeEventListener("click", handleWrapperClick);
            window.removeEventListener("keydown", handleEscapePress);
        };
    }, [onClose]);

    const handleClose: MouseEventHandler<
        HTMLDivElement | HTMLButtonElement
    > = useCallback(() => {
        onClose?.();
    }, [onClose]);

    return isMounted ? (
        <Portal id={MODAL_CONTAINER_ID}>

            <div className={Styles.wrap} ref={rootRef} data-testid="wrap">
                <div className={Styles.nameTitle}>
                    <p className={Styles.nameText}>Маскот </p>
                </div>
                <div className={Styles.mascot}></div>
                <div className={Styles.content}>
                    <div className={Styles.btnPos}>
                        <IconButton
                            onClick={handleClose}
                        >
                            <ThemeProvider theme={theme}>
                                <FastForwardOutlinedIcon color="primary" fontSize="medium"/>
                            </ThemeProvider>
                        </IconButton>
                    </div>
                    <p className={Styles.title}>{title}</p>
                    {children}
                </div>
            </div>
        </Portal>
    ) : null;
};

export default ModalHello;