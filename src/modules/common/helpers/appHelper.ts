import { IAppSettingService } from "../services/iappSettingService";
import { IoCNames } from "..";

let appHelper = {
    getAppSettingValue: getAppSettingValue
}

export default appHelper;

function getAppSettingValue(key: string): string {
    let appSettingService: IAppSettingService = window.ioc.resolve(IoCNames.IAppSettingService);
    var config = appSettingService.getConfig().appSettings.firstOrDefault((item: any) => {
        return item.key == key;
    });
    return !config ? "" : config.value;
}