import { IConfigModel } from "../models/enums";
export interface IAppSettingService {
    getConfig(): IConfigModel;
    setConfig(appConfig: IConfigModel): void;
}