export interface HourlyData {
    time: string[];
    temperature_2m: number[];
}

export interface Data {
    hourly: HourlyData;
}
