import { Component } from "@angular/core";
import { BaseComponent, IProductService, IoCNames } from "@app/common";
import { AddNewProductModel } from "../models/addNewProductModel";
import { Router } from "@angular/router";
@Component({
    template: `
        <page [title]="i18n.inventory.addNewProduct.title">
            <page-content>
                <form-horizontal>
                    <form-input-text
                        [title]="i18n.inventory.addNewProduct.name"
                        [validations]="[
                            'inventory.addNewProduct.nameIsRequired',
                            'inventory.addNewProduct.nameWasUnderMinLength',
                            'inventory.addNewProduct.nameWasExcessMaxLength',
                            'inventory.addNewProduct.nameWasExist'
                        ]"
                        [(model)]="model.name"
                    >
                    </form-input-text>

                    <form-input-number
                        [title]="i18n.inventory.addNewProduct.quantity"
                        [validations]="[
                            'inventory.addNewProduct.quantityIsRequired',
                            'inventory.addNewProduct.quantityShouldGreaterOrEqualThanZero'
                        ]"
                        [type]="'number'"
                        [(model)]="model.quantity"
                    >
                    </form-input-number>

                    <form-input-text
                        [title]="i18n.inventory.addNewProduct.price"
                        [validations]="[
                            'inventory.addNewProduct.priceIsRequired',
                            'inventory.addNewProduct.priceShouldGreateOrEqualThanZero'
                        ]"
                        [type]="'decimal'"
                        [(model)]="model.price"
                    >
                    </form-input-text>
                    
                    <form-input-text
                        [title]="i18n.inventory.addNewProduct.description"
                        [(model)]="model.description"
                    >
                    </form-input-text>

                    <form-buttons>
                        <button-primary [text]="i18n.common.save" (onClicked)="onSaveClicked($event)"></button-primary>
                        <button-default [text]="i18n.common.cancel" (onClicked)="onCancelClicked($event)"></button-default>
                    </form-buttons>

                </form-horizontal>
            </page-content>
        </page>
    `
})
export class AddNewProduct extends BaseComponent {
    public model: AddNewProductModel;
    private router: Router;
    constructor(router:Router) {
        super();
        this.router = router;
        this.model = new AddNewProductModel();
    }

    public onSaveClicked(): void {
        if (!this.model.isValid()) {
            return;
        }
        let self = this;
        let productService: IProductService = window.ioc.resolve(IoCNames.IProductService);
        productService.addProduct(this.model).then(() => {
            self.router.navigate(["/inventory/products"]);
        });
    }

    public onCancelClicked():void{
        this.router.navigate(["/inventory/products"]);
    }
}