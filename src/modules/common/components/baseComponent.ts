import { IResourceManager } from "../services/iresourceManager";
import { IoCNames } from "../models/enums";

export class BaseComponent {
    public i18n: any = {};
    public i18nHelper: IResourceManager;
    constructor() {
        let resourceManager: IResourceManager = window.ioc.resolve(IoCNames.IResourceManager);
        this.i18n = resourceManager.getLocales();
        this.i18nHelper = resourceManager;
    }
}