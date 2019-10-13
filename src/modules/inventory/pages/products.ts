import { Component } from "@angular/core";
import { BaseComponent, IProductService, IoCNames } from "@app/common";
import { ProductsModel } from "../models/productsModel";
import { Router } from "@angular/router";

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
    private router: Router;
    constructor(router: Router) {
        super();
        this.router = router;
        this.model = new ProductsModel(this.i18n);
        let self = this;
        let productService: IProductService = window.ioc.resolve(IoCNames.IProductService);
        productService.getProducts().then((response: Array<ProductsModel>) => {
            self.model.options.data.resolve(response);
        });
        this.model.addButton(this.i18n.inventory.products.addNewProduct, "plus", () => {
            self.onAddNewProductClicked();
        });
    }

    private onAddNewProductClicked(): void {
        this.router.navigate(["/inventory/addNewProduct"]);
    }
}