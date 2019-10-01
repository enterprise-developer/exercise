import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { Layout } from "./layout";
import {Promise, PromiseFactory} from "./modules/common/models/promise";
import {IConnector} from "./modules/common/connector/iconnector";
import {ConnectorFactory} from "./modules/common/connector/connectorFactory";
import { ConnectorType } from "./modules/common/enum";
let routes : Routes=[
    {path:"learning",loadChildren:"src/modules/learning/learningModule.js#LearningModule"}
]
@NgModule({
    imports:[RouterModule.forRoot(routes)]
    //bootstrap:[Layout]
})
export class AppModule{
    public ngDoBootstrap():void{
        // private, 1 parameter:["learning", "productManagement"]: Array<string> , return promise
        this.loadJsones(locales).then(()=>{
            self.appRef.bootstrap(Layout);
        });

    }
    private loadJsones(locales: Array<string>):Promise{
        let def: Promise= PromiseFactory.create();
        let self=this;
        locales.forEach(function(locale:string){
            def.resolveAll(
                self.getLocaleByName(locale)
            );
        });
        return def;
    }
    // locale: learning => get json from /resources/locales/learning.en.json
    private getLocaleByName(locale:string):Promise{
        let uri:string=String.format("/resources/locales/{0}.en.json", locale);
        let connector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        // public, promise, 1 param: string
        return connector.get(uri);
    }
}