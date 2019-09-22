import { IGridOption } from "src/modules/common/components/grid/igridOption";
import { PromiseFactory } from "src/modules/common/models/promise";
import { BasePageModel } from "@app/common";
import { Products } from "../pages/products";
export class ProductsModel extends BasePageModel {

    public options: IGridOption;
    private i18n: any = {};
    constructor(page: Products) {
        super();
        this.i18n = page.i18n;
        this.options = {
            data: PromiseFactory.create(),
            columns: [
                {
                    title: this.i18n.business.products.name, field: "name"
                },
                {
                    title: this.i18n.business.products.quantity, field: "quantity"
                },
                {
                    title: this.i18n.business.products.price, field: "price"
                },
                {
                    title: this.i18n.business.products.description, field: "description"
                },
            ],
            actions: [
                {
                    text: this.i18n.common.edit,
                    handler: (item: any) => {
                        page.onEditProduct(item)
                    }
                },
                {
                    text: this.i18n.common.delete,
                    handler: (item: any) => {
                        page.onDeleteProduct(item)
                    }
                }
            ]
        }
    }
}