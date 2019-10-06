import { Promise } from "../models/promise";

export interface IProductService {
    getProducts(): Promise;
}