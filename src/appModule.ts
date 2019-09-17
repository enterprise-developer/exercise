import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
let routes : Routes=[
    {path:"learning",loadChildren:"src/modules/learning/learningModule.js#LearningModule"}
]
@NgModule({
    imports:[RouterModule.forRoot(routes)]

})
export class AppModule{}