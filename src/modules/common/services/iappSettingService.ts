import { IConfigModel } from "..";

export interface IAppSettingService {
    getConfig(): IConfigModel;
    setConfig(appConfig: IConfigModel): void;
}