import { IGridOption } from "@app/common";
import { PromiseFactory } from "@app/common";
import {UserStatus} from "../_shared/models/enum";
import { Users } from "./users";

export class UsersModel{
    public options:IGridOption;
    constructor(page: Users){
        let i18nHelper=page.i18nHelper;
        this.options={
            dataSource:PromiseFactory.create(),
            columns:[
                {field:"firstName", title: page.i18n.users.firstName},
                {field:"lastName", title: page.i18n.users.lastName},
                {field:"userName", title: page.i18n.users.userName},
                {field:"status", title: page.i18n.users.status, transform:(val: any)=>{
                    let text=UserStatus[val];
                    text=String.toCamelCase(text);
                    let local:string=String.format("users.userStatus.{0}", text);
                    let  localText:string=i18nHelper.resolve(local);
                    return String.format("<span>{0}</span>", localText);
                }},
            ],
            actions:[
                {
                    text:page.i18n.users.inactive, 
                    handler:(item: any)=>{
                        page.onInActiveUserClicked(item);
                    },
                    isValid:(user: any)=>{return user.status==UserStatus.Active;}
                },
                {
                    text:page.i18n.users.active, 
                    handler:(item: any)=>{
                        page.onActiveUserClicked(item);
                    },
                    isValid:(user: any)=>{return user.status!=UserStatus.Active;}
                },
                {
                    text:page.i18n.users.edit, 
                    handler:(item: any)=>{
                        page.onEditUserClicked(item);
                    }
                },
                {
                    text:page.i18n.users.delete, 
                    handler:(item: any)=>{
                        page.onDeleteUserClicked(item);
                    }
                }
            ]
        }
    }
}