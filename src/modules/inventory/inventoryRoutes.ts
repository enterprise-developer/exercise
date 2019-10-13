import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppCommonModule } from "@app/common";
import { Products } from "./pages/products";
import { AddNewProduct } from "./pages/addNewProduct";

let routes: Routes = [
    { path: "", redirectTo: "products", pathMatch: "full" },
    { path: "products", component: Products },
    { path: "addNewProduct", component: AddNewProduct }
];

@NgModule({
    imports: [
        AppCommonModule,
        RouterModule.forChild(routes)
    ],
    declarations: [
        Products,
        AddNewProduct
    ]
})
export class InventoryRoutes {

}