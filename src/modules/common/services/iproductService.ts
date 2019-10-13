import { Promise } from "../models/promise";

export interface IProductService {
    getProducts(): Promise;
    addProduct(item: any): Promise;
}