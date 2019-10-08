import { NgModule } from "@angular/core";
import { InventoryRoutes } from "./inventoryRoutes";
import { AppCommonModule } from "@app/common";
@NgModule({
    imports: [
        InventoryRoutes,
        AppCommonModule
    ]
})
export class InventoryModule { }