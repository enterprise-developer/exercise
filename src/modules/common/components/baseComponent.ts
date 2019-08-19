import { IResourceManager } from "../services/iresourceManager";
import { IoCNames } from "../models/enums";
export class BaseComponent {
    public i18nHelper: IResourceManager;
    constructor() {
        this.i18nHelper = window.ioc.resolve(IoCNames.IResourceManager);
    }
}