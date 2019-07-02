import {required} from "@app/common";
import {BaseModel} from "@app/common";

export class AddNewUserModel extends BaseModel{
    @required("addNewUser.firstNameWasRequired")
    public firstName:string;
    @required("addNewUser.lastNameWasRequired")
    public lastName:string;
    public userName: string;
}