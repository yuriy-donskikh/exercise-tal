import { IRoomTime } from "./room-time";

export interface IRoom {
    roomId: number;
    name: string;
    date: string;
    start: string;
    end: string;
    times: IRoomTime[];
}