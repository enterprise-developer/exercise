import { Component } from "@angular/core";
import { AddNewProductModel } from "../models/addNewProductModel";
import { IProductService } from "../services/iproductService";
import { IoCNames } from "@app/common";
import { Router } from "@angular/router";
import { AddOrEditProduct } from "./addOrEditProduct";
@Component({
    template: `
    <add-edit-product [title]="i18n.business.addProduct.title" [model]="product"></add-edit-product>
    `
})
export class AddNewProduct extends AddOrEditProduct {
    private product: AddNewProductModel;
    constructor(router:Router) {
        super(router);
        this.product = new AddNewProductModel();
    }
}
