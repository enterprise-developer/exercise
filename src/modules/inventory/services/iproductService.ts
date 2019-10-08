import { Promise } from "../../common/models/promise";

export interface IProductService {
    getProducts(): Promise;
}