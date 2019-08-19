import { AppCommonModule } from "@app/common";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { Students } from "./pages/students";
import { AddNewStudent } from "./pages/addNewStudent";
let routes: Routes = [
    { path: "", redirectTo: "students", pathMatch: "full" },
    { path: "students", component: Students },
    { path: "students/addNew", component: AddNewStudent }
];
@NgModule({
    imports: [
        AppCommonModule,
        RouterModule.forChild(routes)
    ],
    declarations: [
        Students,
        AddNewStudent
    ]

})
export class LearningRoutes {

}