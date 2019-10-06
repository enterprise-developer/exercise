import { Promise } from "./promise";

export interface IGridOption {
    columns: Array<IGridColumn>;
    data: Promise;
}

export interface IGridColumn {
    field: string;
    title: string;
}