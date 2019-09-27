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
        /*
         module learning => learning.en.json
         .... load learning.en.json => ....
         return ....

         getLocale:
         - public
         - no parameter
         - return any
        */
        this.i18n= resource.getLocale();
    }
}