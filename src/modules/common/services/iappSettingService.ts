import { IConfigModel } from "../models/iconfigModel";
export interface IAppSettingService {
    getConfig(): IConfigModel;
    setConfig(config: IConfigModel): void;
}