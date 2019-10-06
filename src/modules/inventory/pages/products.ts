import { Component } from "@angular/core";
import { BaseComponent, IProductService, IoCNames } from "@app/common";
import { ProductsModel } from "../models/productsModel";

@Component({
    template: `
        <page [title]="i18n.inventory.products.title">
            <page-commands>
                <buttons [items]="model.buttons">
                </buttons>
            </page-commands>

            <page-content>
                <grid [options]="model.options">
                </grid>
            </page-content>
        </page>
    `
})
export class Products extends BaseComponent {

    public model: ProductsModel;
    constructor() {
        super();
        this.model = new ProductsModel(this.i18n);
        let self = this;
        let productService: IProductService = window.ioc.resolve(IoCNames.IProductService);
        productService.getProducts().then((response: Array<ProductsModel>) => {
            self.model.options.data.resolve(response);
        });
    }
}