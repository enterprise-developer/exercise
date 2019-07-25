import {IResourceManager} from "../services/iresourceManager";
import {IoCNames} from "../models/enums";
export class BasePage {
    public i18n: any = {};
    constructor() {
        let resourceManager: IResourceManager = window.ioc.resolve(IoCNames.IResourceManager);
        this.i18n = resourceManager.getLocales();
    }
}