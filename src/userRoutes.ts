import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
let routes: Routes = [
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class UserRoutes { }