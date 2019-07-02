import { Promise } from "@app/common";

export interface IUserService{
    getUsers():Promise;
    createUser(model: any):Promise;
}