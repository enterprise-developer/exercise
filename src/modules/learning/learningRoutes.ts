import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { Students } from "./pages/students";
import { AppCommonModule } from "@app/common";
let routes: Routes = [
    { path: "", redirectTo: "students", pathMatch: "full" },
    { path: "students", component: Students }
];
@NgModule({
    imports: [
        AppCommonModule,
        RouterModule.forChild(routes)
    ],
    declarations: [
        Students
    ]

})
export class LearningRoutes {

}