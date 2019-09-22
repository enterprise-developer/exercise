import { IAppSettingService } from "./iappSettingService";
import { IConfigModel } from "../models/iconfigModel";
export class AppSettingService implements IAppSettingService {
    private config: IConfigModel;
    public getConfig(): IConfigModel {
        return this.config;
    }

    public setConfig(config: IConfigModel): void {
        this.config = config;
    }
}