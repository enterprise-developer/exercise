import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
let routes: Routes = [
    { path: "", redirectTo: "inventory", pathMatch: "full" },
    { path: "inventory", loadChildren: "src/modules/inventory/inventoryModule#InventoryModule" }
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class UserRoutes { }