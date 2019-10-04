import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import {CommonModule} from "@angular/common";
import {FormsModule} from "@angular/forms";
import { Courses} from "./pages/courses";
let routes : Routes=[
    {path:"courses",component:Courses}
];
 @NgModule({
     imports:[CommonModule, FormsModule, RouterModule.forChild(routes)],
     declarations:[Courses]
 })
 export class LearningRoutes{}