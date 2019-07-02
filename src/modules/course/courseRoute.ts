import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppCommonModule } from "../common/commonModule";
import { Courses } from "./pages/courses";
import { AddNewCourse } from "./pages/addNewCourse";
let routes: Routes = [
    { path: "", redirectTo: "courses", pathMatch: "full" },
    { path: "courses", component: Courses },
    { path: "addNewCourse", component: AddNewCourse }
];
@NgModule({
    imports: [
        AppCommonModule,
        RouterModule.forChild(routes)
    ],
    declarations: [
        Courses,
        AddNewCourse
    ]
})

export class CourseRoute { }