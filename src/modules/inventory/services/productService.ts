import { IProductService } from "./iproductService";
import { IConnector } from "@app/common";
import { ConnectorFactory } from "@app/common";
import { ConnectorType } from "@app/common";
import { Promise } from "@app/common";
import { BaseService } from "@app/common";
import { ProductConst } from "../models/enums";
export class ProductService extends BaseService implements IProductService {
    constructor() {
        super(ProductConst.DomainApiKey);
    }
    public getProducts(): Promise {
        let url: string = "/inventory/products";
        let iconnector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        return iconnector.get(this.resolveUrl(url));
    }
}