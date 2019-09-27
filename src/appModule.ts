import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { Layout } from "./layout";
let routes : Routes=[
    {path:"learning",loadChildren:"src/modules/learning/learningModule.js#LearningModule"}
]
@NgModule({
    imports:[RouterModule.forRoot(routes)]
    //bootstrap:[Layout]
})
export class AppModule{
    public ngDoBootstrap():void{
        //load json file: 
            // learning.vn.json
            // productManage.vn.json
        // bootstrap layout
        this.loadJsones(files).then(()=>{
            // bootstrap layout
            self.appRef.bootstrap(Layout);
        });

    }
}