import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
let routes: Routes = [
    { path: "learning", loadChildren: "/src/modules/learning/learningModule#LearningModule" }
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutes { }