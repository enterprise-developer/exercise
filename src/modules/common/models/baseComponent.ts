import { IResourceManager } from "../services/iresourceManager";
import { IoCNames } from "./enum";
import guidHelper from "../helpers/guidHelper";
export class BaseComponent{
    public i18n:any={};
    public i18nHelper:IResourceManager;
    public id:string;
    constructor(){
        this.id=String.format("ctrl_{0}", guidHelper.newGuid());
        let resourceManager:IResourceManager = window.ioc.resolve(IoCNames.IResourceManager);
        this.i18n=resourceManager.getLocales();
        this.i18nHelper=resourceManager;
    }
}