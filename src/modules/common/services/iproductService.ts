import { Promise } from "../models/promise";
import { AddNewProductModel } from "src/modules/inventory/models/addNewProductModel";

export interface IProductService {
    getProducts(): Promise;
    addProduct(product: AddNewProductModel): Promise;
}