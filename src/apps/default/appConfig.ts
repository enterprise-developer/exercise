import { IAppConfigModel, AppConst } from "@app/common";

let appConfig: IAppConfigModel = {
    domains: [
        {
            key: AppConst.InventoryUrlApi,
            value: "http://inventory.com/api"
        }
    ]
};
export default appConfig;