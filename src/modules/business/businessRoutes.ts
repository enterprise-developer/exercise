import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { Products } from "./pages/products";
import { AddNewProduct } from "./pages/addNewProduct";
import { AppCommonModule } from "@app/common";
import { EditProduct } from "./pages/editProduct";
let routes: Routes = [
    { path: "", redirectTo: "products", pathMatch: "full" },
    { path: "/products", component: Products },
    { path: "/products/addNewProduct", component: AddNewProduct },
    { path: "/products/id", component: EditProduct }
];
@NgModule({
    imports: [
        AppCommonModule,
        RouterModule.forChild(routes)
    ]

})
export class BusinessRoutes {

}