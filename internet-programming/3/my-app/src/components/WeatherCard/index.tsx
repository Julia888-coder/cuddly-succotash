import React, {FC} from "react";
import {formatDate} from "../../utils/formatDate";

import styles from './style.module.css';

interface Props {
    time: string;
    temperature: number;
}

export const WeatherCard: FC<Props> = ({ time, temperature }) => {

    const dateFormatted = formatDate(time);
    const temperatureFormatted = `${temperature}°C`

    return (
        <div className={styles.card}>
            <div className={styles.date}>{dateFormatted}</div>
            <div className={styles.temp}>Температура - {temperatureFormatted}</div>
        </div>
    )
}
