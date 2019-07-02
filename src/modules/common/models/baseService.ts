import appHelper from "../helpers/appHelper";
export class BaseService {
    private baseUrl: string;
    constructor(appSettingKey: string) {
        this.baseUrl = appHelper.getAppSettingValue(appSettingKey);
    }

    protected resolve(url: string): string {
        return this.baseUrl + url;
    }
}