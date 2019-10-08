import { IoCNames, IConfigDomain } from "../models/enums";
import { IAppSettingService } from "../services/iappSettingService";
let urlHelper: any = {
    getApiUrl: getApiUrl
};
export default urlHelper;

function getApiUrl(domainKey: string): string {
    let appSettingService: IAppSettingService = window.ioc.resolve(IoCNames.IAppSettingService);
    return appSettingService.getConfig().domains.firstOrDefault((item: IConfigDomain) => {
        return item.key == domainKey;
    }).value;
}