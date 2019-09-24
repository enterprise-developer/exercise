import {IResourceManager} from "./services/iresourceManager";
export class BasePage{
    public i18n:any
    constructor(){
        /*
        [
            {name:"IResourceManager1", instanceOf: ResourceManager, lifecycle: Trainsient}
            {name:"IResourceManager2", instanceOf: ResourceManager, lifecycle: Singleton}
            

        ]
        */
        let resource : IResourceManager = window.ioc.resolve("IResourceManager");
        this.i18n= resource.getLocale();
    }
}