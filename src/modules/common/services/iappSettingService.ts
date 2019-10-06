import { IAppConfigModel } from "../models/enums";

export interface IAppSettingService {
    getConfig(): IAppConfigModel;
    setConfig(config: IAppConfigModel): void;
}