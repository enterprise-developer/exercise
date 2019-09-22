import { Component, Input } from "@angular/core";
import { BaseComponent, IoCNames } from "@app/common";
import { AddNewProductModel } from "../models/addNewProductModel";
import { Router } from "@angular/router";
import { IProductService } from "../services/iproductService";

@Component({
    selector: "add-edit-product",
    template: `
    <page [title]="{{title}}">
    <page-content>
        <form-horizontal>
            <form-input-text
                [title]="i18n.business.addEditProduct.name"
                [validations]="[
                    'business.addEditProduct.nameIsRequired',
                    'business.addEditProduct.nameWasUnderMinLength',
                    'business.addEditProduct.nameWasExcessMaxLength',
                    'business.addEditProduct.nameWasExist',
                ]"
                [(model)]="model.name"    
            >
            </form-input-text>

            <form-input-text
                [title]="i18n.business.addEditProduct.quantity"
                [validations]="[
                    'business.addEditProduct.quantityShouldGreaterOrEqualThanZero'
                ]"
                [(model)]="model.quantity"    
            >
            </form-input-text>

            <form-input-text
                [title]="i18n.business.addEditProduct.price"
                [validations]="[
                    'business.addEditProduct.priceShouldGreaterOrEqualThanZero'
                ]"
                [(model)]="model.price"    
            >
            </form-input-text>

            
            <form-input-text
                [title]="i18n.business.addEditProduct.description"
                [(model)]="model.description"    
            >
            </form-input-text>

            <form-buttons>
                <button-primary (onClicked)="onSaveClicked($event)" [text]="i18n.common.save" ></button-primary>
                <button-default (onClicked)="onCancelClicked($event)" [text]="i18n.common.cancel"></button-default>
            </form-buttons>
        </form-horizontal>
    </page-content>
</page>

    `
})
export class AddOrEditProduct extends BaseComponent {
    @Input() text: string;
    @Input() model: AddNewProductModel;
    private router: Router;
    constructor(router: Router) {
        super();
        this.router = router;
    }

    public onSaveClicked(): void {
        if (!this.model.isValid()) {
            return;
        }

        let self = this;
        let productService: IProductService = window.ioc.resolve(IoCNames.IProductService);
        productService.addNewProduct(this.model).then(() => {
            self.router.navigate(["/business/products"]);
        });
    }

    public onCancelClicked(): void {
        this.router.navigate(["/business/products"]);
    }
}