import { Promise } from "@app/common";
import { AddNewProductModel } from "../models/addNewProductModel";
export interface IProductService {
    getProducts(): Promise;
    addNewProduct(model: AddNewProductModel): Promise;
    getProductById(id: number): Promise;
    deleteProduct(id: number): Promise;
}