import { Component } from "@angular/core";
import { AddNewProductModel } from "../models/addNewProductModel";
import { IProductService, IoCNames } from "@app/common";
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
                        [(model)]="model.quantity"
                        [type]="'number'"
                    >
                    </form-input-number>

                    <form-input-number
                        [title]="i18n.inventory.addNewProduct.price"
                        [validations]="[
                            'inventory.addNewProduct.priceIsRequired',
                            'inventory.addNewProduct.priceShouldGreaterOrEqualThanZero'
                        ]"
                        [(model)]="model.price"
                        [type]="'decimal'"
                    >
                    </form-input-number>

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
export class AddNewProduct {
    public model: AddNewProductModel;
    private router: Router;
    constructor(router: Router) {
        this.router = router;
        this.model = new AddNewProductModel();
    }

    public onSaveClicked(): void {
        if (this.model.isValid() == false) {
            return;
        }
        let self = this;
        let productService: IProductService = window.ioc.resolve(IoCNames.IProductService);
        productService.addProduct(this.model).then(() => {
            self.router.navigate(["/inventory/products"]);
        });
    }

    public onCancelClicked(): void {
        this.router.navigate(["/inventory/products"]);
    }
}