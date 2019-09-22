import { IGridColumn } from "./igridColumn";
import { Promise } from "../../models/promise";
import {IGridAction} from "./igridAction";
export interface IGridOption {
    columns: Array<IGridColumn>;
    data: Promise;
    actions?:Array<IGridAction>;
}