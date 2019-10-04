import { IResourceManager } from "./iresourceManager";
import { Promise, PromiseFactory } from "../models/promise";
import { IConnector } from "../connector/iconnector";
import { ConnectorFactory } from "../connector/connectorFactory";
import { ConnectorType } from "../enum";


export class ResourceManager implements IResourceManager{
    private locales:any={};
    public getLocale():any{
        return this.locales;
    }
    public loadLocales(locales:Array<string>):Promise{
        let def: Promise= PromiseFactory.create();
        let self=this;
        locales.forEach(function(locale:string){
            def.resolveAll(
                self.getLocaleByName(locale)
            );
        });
        return def;
    }
    private getLocaleByName(locale:string):Promise{
        let uri:string=String.format("/resources/locales/{0}.en.json", locale);
        let connector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        // public, promise, 1 param: string
        let self=this;
        return connector.get(uri).then((json)=>{
            self.locales[locale]=json;
        });
        /*
        this.i18n.learning.pages.courses.title_
        this.i18n=locales={
            "learning":{
                "title":"Learning",
                'pages':{
                    "courses":{
                        "title_":"Course management"
                    }
                }
            },
            "common":{

            }
        };
        learning.en.json={
            "title":"Learning",
            'pages':{
                "courses":{
                    "title_":"Course management"
                }
            }
        }
        */
    }
}