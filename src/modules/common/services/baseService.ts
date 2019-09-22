import {IAppSettingService} from "./iappSettingService";
import { IoCNames } from "../models/enums";
import { IConfigDomain } from "../models/iconfigModel";
export class BaseSevice {
    private domainUrl: string;
    constructor(domainKey: string) {
        let appSettingService: IAppSettingService = window.ioc.resolve(IoCNames.IAppSettingService);
        this.domainUrl = appSettingService.getConfig().domains.firstOrDefault((item: IConfigDomain) => {
            return item.key == domainKey;
        }).value;
    }
    public resolveUrl(subUrl: string): string {
        return this.domainUrl + subUrl;
    }
}