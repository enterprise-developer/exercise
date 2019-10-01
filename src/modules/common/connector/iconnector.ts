import { Promise } from "../models/promise";

export interface IConnector{
    get(uri:string):Promise;
}