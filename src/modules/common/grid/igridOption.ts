import { Promise } from "../models/promise";
export interface IGridOption {
    data: Promise;
    columns: Array<IGridColumn>;
}

export interface IGridColumn {
    title:string;
    field:string;
}
