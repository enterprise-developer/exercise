import { IConfigModel } from "./appSettingService";
export interface IAppSettingService {
    getConfig(): IConfigModel;
    setConfig(appConfig: IConfigModel): void;
}