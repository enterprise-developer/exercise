import { Promise } from "../models/promise";
export interface IConnector {
    get(url: string): Promise;
    post(url: string, model: any): Promise;
    delete(url: string): Promise;
}