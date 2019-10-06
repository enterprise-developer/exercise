import { IAppSettingService } from "./iappSettingService";
import { IAppConfigModel } from "../models/enums";

export class AppSettingService implements IAppSettingService {
    private config: IAppConfigModel;
    public getConfig(): IAppConfigModel {
        return this.config;
    }

    public setConfig(config: IAppConfigModel): void {
        this.config = config;
    }
}