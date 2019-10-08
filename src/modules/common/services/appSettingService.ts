import { IAppSettingService } from "./iappSettingService";
import { IConfigModel } from "../models/enums";

export class AppSettingService implements IAppSettingService {
    private config: IConfigModel;
    public getConfig(): IConfigModel {
        return this.config;
    }
    public setConfig(appConfig: IConfigModel): void {
        this.config = appConfig;
    }
}