import { IProductService } from "./iproductService";
import { IConnector } from "../connector/iconnector";
import { ConnectorFactory } from "../connector/connectorFactory";
import { ConnectorType, AppConst } from "../models/enums";
import { Promise } from "../models/promise";
import { BaseService } from "./baseService";

export class ProductService extends BaseService implements IProductService {
    constructor() {
        super(AppConst.InventoryUrlApi);
    }
    public getProducts(): Promise {
        let url: string = "/products";
        let connector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        return connector.get(this.resolveUrl(url));
    }
}