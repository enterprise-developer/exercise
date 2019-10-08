import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
let routes: Routes = [
    { path: "", redirectTo: "inventoryModule", pathMatch: "full" },
    { path: "inventoryModule", loadChildren: "src/modules/inventory/inventoryModule#InventoryModule" }
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutes { }