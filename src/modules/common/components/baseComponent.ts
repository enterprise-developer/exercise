import { IResourceManager } from "../services/iresourceManager";
import { IoCNames } from "../models/enums";
export class BaseComponent {
    public i18nHelper: IResourceManager;
    protected i18n = {};
    constructor() {
        this.i18nHelper = window.ioc.resolve(IoCNames.IResourceManager);
        this.i18n = this.i18nHelper.getLocales();
    }
}