import { NgModule, Injector, AppRef } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { Layout } from "./layout";
import {Promise, PromiseFactory} from "./modules/common/models/promise";
import {IConnector} from "./modules/common/connector/iconnector";
import {ConnectorFactory} from "./modules/common/connector/connectorFactory";
import { ConnectorType,IoCNames } from "./modules/common/enum";
import { IResourceManager } from "./modules/common/services/iresourceManager";
let routes : Routes=[
    {path:"learning",loadChildren:"src/modules/learning/learningModule.js#LearningModule"}
]
@NgModule({
    imports:[RouterModule.forRoot(routes)],
    entryComponents:[Layout]
})
export class AppModule{
    private appRef:AppRef;
    constructor(injector:Injector, appRef: AppRef){
        window.ioc.setInjector(injector);
        this.appRef=appRef;
    }
    public ngDoBootstrap():void{
        let locales:Array<string>=["learning"];
        let self=this;
        let resource: IResourceManager = window.ioc.resolve(IoCNames.IResourceManager);
        resource.loadLocales(locales).then(()=>{
            self.appRef.bootstrap(Layout);
        });
    }
}