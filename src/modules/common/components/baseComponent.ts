import { IResourceService, IoCNames } from "@app/common";
export class BaseComponent {
    public i18n: any = {};
    public i18nHelper: IResourceService;
    constructor() {
        let resourceService: IResourceService = window.ioc.resolve(IoCNames.IResourceService);
        this.i18n = resourceService.getLocales();
        this.i18nHelper = resourceService;
    }
}