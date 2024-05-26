import {Data} from "./types";

// Получаем погоду по координатам
export const getWeatherToLocation = async (latitude: number, longitude: number): Promise<Data> => {
    return fetch(`https://api.open-meteo.com/v1/forecast?latitude=${latitude}&longitude=${longitude}&hourly=temperature_2m`)
    //Получаем data и переводим в json
      .then((data) => data.json())
}
