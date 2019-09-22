import { IConnector } from "src/modules/common/connector/iconnector";
import { ConnectorFactory } from "src/modules/common/connector/connectorFactory";
import { Promise, ConnectorType, IoCNames, ProductUrl } from "@app/common";
import { BaseSevice } from "@app/common";
import { IProductService } from "./iproductService";
import { AddNewProductModel } from "../models/addNewProductModel";
export class ProductService extends BaseSevice implements IProductService {

    constructor() {
        super(ProductUrl.API);
    }
    public addNewProduct(model: AddNewProductModel): Promise {
        let url: string = "/products";
        let connector: IConnector = window.ioc.resolve(IoCNames.IProductService);
        return connector.post(this.resolveUrl(url), model);
    }
    public getProducts(): Promise {
        let url = "/products";
        let iConnector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        return iConnector.get(this.resolveUrl(url));
    }

    public getProductById(id: number): Promise {
        let url = String.format("/products/id={0}", id);
        let connector: IConnector = window.ioc.resolve(ConnectorType.Json);
        return connector.get(url);
    }

    public deleteProduct(id: number): Promise {
        let url: string = "/products";
        let connector: IConnector = window.ioc.resolve(ConnectorType.Json);
        return connector.delete(url);
    }
}