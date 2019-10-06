import { IoCNames, IAppConfigModel, IDomainConfig } from "../models/enums";
import { IAppSettingService } from "./iappSettingService";

export class BaseService {
    private domainUrl: string;
    constructor(domainKey: string) {
        let appSettingService: IAppSettingService = window.ioc.resolve(IoCNames.IAppSettingService);
        let appConfig: IAppConfigModel = appSettingService.getConfig();
        if (!appConfig) {
            throw String.format("Cannot get config for app!");
        }

        if (!appConfig.domains) {
            throw String.format("Cannot found domain for app!");
        }

        let domainConfig: IDomainConfig = appConfig.domains.firstOrDefault((item: IDomainConfig) => {
            return item.key == domainKey;
        });

        if (!domainConfig) {
            throw String.format("Cannot found domain url with key: {0}", domainKey);
        }

        this.domainUrl = domainConfig.value;
    }

    public resolveUrl(url: string): string {
        return this.domainUrl + url;
    }
}