import { IButtonModel, IGridOption, BaseModel } from "@app/common";
import { PromiseFactory } from "src/modules/common/models/promise";


export class ProductsModel extends BaseModel {
    public options: IGridOption;
    private i18n: any = {};
    constructor(i18n: any) {
        super();
        this.i18n = i18n;
        this.options = {
            data: PromiseFactory.create(),
            columns: [
                { title: this.i18n.inventory.products.name, field: "name" },
                { title: this.i18n.inventory.products.quantity, field: "quantity" },
                { title: this.i18n.inventory.products.price, field: "price" },
                { title: this.i18n.inventory.products.description, field: "description" }
            ]
        }
    }
}