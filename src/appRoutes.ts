import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
let routes: Routes = [
    {path:"", redirectTo:'business', pathMatch:"full"},
    {path:"business", loadChildren:"src/modules/business/businessModule#BusinessModule"}
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutes { }