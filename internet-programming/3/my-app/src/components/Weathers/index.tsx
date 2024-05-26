import React, {useEffect, useState} from "react";
import {HourlyData} from "../../api/types";
import {getWeatherToLocation} from "../../api";
import {latitude, longitude} from "../../constants";
import {WeatherCard} from "../WeatherCard";

import styles from './style.module.css';

export const Weathers = () => {
    const [data, setData] = useState<HourlyData>();

    useEffect(() => {
        getWeatherToLocation(latitude, longitude)
            .then((response) => setData(response.hourly))
    }, [])

    return (
        <div className={styles.wrapper}>
            <h1>Погода</h1>
            <div className={styles.weathers}>
                {
                    data?.time.map((time, idx) => <WeatherCard time={time} temperature={data?.temperature_2m[idx]}/>)
                }
            </div>
        </div>
    )
}
