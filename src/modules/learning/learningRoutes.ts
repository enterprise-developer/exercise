import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { Courses} from "./pages/courses";
let routes : Routes=[
    {path:"courses",component:Courses}
];
 @NgModule({
     imports:[RouterModule.forChild(routes)]
 })
 export class LearningRoutes{}