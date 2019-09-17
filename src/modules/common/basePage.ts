import {IResourceManager} from "./services/iresourceManager";
export class BasePage{
    public i18n:any
    constructor(){
        let resource : IResourceManager = window.ioc.resolve("IResourceManager");
        this.i18n= resource.getLocale();
    }
}