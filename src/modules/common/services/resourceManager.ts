import { IResourceManager } from "./iresourceManager";
import { Promise, PromiseFactory } from "../models/promise";
import { IConnector } from "../connector/iconnector";
import { IoCNames, LanguageCode } from "../models/enum";
import templateHelper from "../helpers/templateHelper";
export class ResourceManager implements IResourceManager{
    private numberOfLocales: number=0;
    private locales:any={};
    private languageCode:string = LanguageCode.EN;
    private localeNames:Array<string>=[];
    public changeLanguage(languageCode:string):void{
        this.languageCode=languageCode;
        this.reload();
    }
    private reload():void{
        this.load(this.localeNames);
    }
    public load(locales:Array<any>):Promise{
        locales=locales||[];
        this.numberOfLocales=locales.length;
        this.localeNames=locales;
        
        let def:Promise = PromiseFactory.create();
        let self=this;
        locales.forEach((name:string)=>{
            def.resolveAll(self.loadByName(name));
        });
        return def;
    }
    public getLocales():any{
        return this.locales;
    }
    private loadByName(name:string):Promise{
        let def:Promise = PromiseFactory.create();
        let url:string=String.format("/resources/locales/{0}.{1}.json", name, this.languageCode);
        let iconnector: IConnector = window.ioc.resolve(IoCNames.IConnector);
        iconnector.get(url).then((jsonData:any)=>{
            this.locales[name]=jsonData;
            def.resolve();
        });
        return def;
    }
    /**
     * 
     * locales={
     *      common:{},
            * users:{},
            * addNewUser:{
                    "title":"Add new user",
                    "firstName":"First name",
                    "lastName":"Last name",
                    "userName":"User name",
                    "firstNameWasRequired":"First name was requried"
                }
     * };
     * addNewUser.firstNameWasRequired.invalid =>First name was requried
     * segments = [addNewUser,firstNameWasRequired, invalid]
     * 
     * result="First name was requried"
     */
    public resolve(key:string, context:any=null):string{
        let segments:Array<string>=key.split(".");
        let result=this.locales;
        segments.forEach((segment:string)=>{
            result=result[segment];
        });
        result = templateHelper.compile(result, context);
        return result;
    }
}