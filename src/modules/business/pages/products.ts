import { Component } from "@angular/core";
import { BaseComponent, IoCNames } from "@app/common";
import { ProductsModel } from "../models/productsModel";
import { IProductService } from "../services/iproductService";
import { Router } from "@angular/router";

@Component({
    template: `
    <page [title]="i18n.business.products.title">

        <page-commands>
            <buttons [items]="model.buttons">
            </buttons>
        </page-commands>

        <page-content>
            <grid [options]="model.options"></grid>
        </page-content>
    </page>
`
})
export class Products extends BaseComponent {
    public model: ProductsModel;
    public router: Router;
    constructor(router: Router) {
        super();
        this.router = router;
        this.model = new ProductsModel(this.i18n);
        let service: IProductService = window.ioc.resolve(IoCNames.IProductService);
        let self = this;
        service.getProducts().then((response: Array<ProductsModel>) => {
            self.model.options.data.resolve(response);
        });
        self.model.addButton(this.i18n.business.products.addNew, "fa-plus", () => {
            self.onAddNewClicked();
        })
    }

    public onAddNewClicked(): void {
        this.router.navigate(["/business/products/addNewProduct"]);
    }

    public onEditProduct(product: any): void {
        this.router.navigate([String.format("/business/products/id={0}", product.id)]);
    }

    public onDeleteProduct(product: any) {
        let self= this;
        let service: IProductService = window.ioc.resolve(IoCNames.IProductService);
        service.deleteProduct(product.id).then(() => {
            self.router.navigate(["/business/products"]);
        });
    }
}