import { Component } from "@angular/core";
import { AddOrEditProduct } from "./addOrEditProduct";
import { ActivatedRoute, Router } from "@angular/router";
import { IProductService } from "../services/iproductService";
import { IoCNames } from "@app/common";
import { AddNewProductModel } from "../models/addNewProductModel";

@Component({
    template: `
    <add-edit-product [title]="i18n.business.editProduct.title" [model]="product"></add-edit-product>
    `
})
export class EditProduct extends AddOrEditProduct {
    private id: string;
    private product:AddNewProductModel;
    constructor(activateRoute: ActivatedRoute, route: Router) {
        super(route);
        activateRoute.queryParams.subscribe((params: any) => {
            this.id = params["id"];
        });

        let productService: IProductService = window.ioc.resolve(IoCNames.IProductService);
        productService.getProductById(this.id).then((response: any) => {
            this.product = response;
        });
    }
}