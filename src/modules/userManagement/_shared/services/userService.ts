import "rxjs/Rx";
import {Promise} from "@app/common";
import {IConnector} from "@app/common";
import { IoCNames } from "@app/common";
import { IUserService } from "./iuserService";
import { BaseService } from "src/modules/common/models/baseService";
export class UserService extends BaseService implements IUserService {
    constructor(){
        super("TINYERP.USER.API_ENDPOINT");
    }
    public getUsers(): Promise {
        let connector: IConnector = window.ioc.resolve(IoCNames.IConnector);
        let url:string="/users";
        return connector.get(this.resolve(url));
    }
    public createUser(model: any):Promise{
        let connector: IConnector = window.ioc.resolve(IoCNames.IConnector);
        let url:string="/users";
        return connector.post(this.resolve(url), model);
    }
}