import { Component } from "@angular/core";
import { BasePage, IoCNames } from "@app/common";
import {UserGroupsModel} from "./userGroupsModel";
import {IUserGroupService} from "../_shared/services/iuserGroupService";
@Component({
    template:`
    <page [title]="i18n.userGroups.title">
        <page-commands>
            <a (click)="onAddNewUserGroupClicked($event)"><i class="fa fa-plus"></i></a>
        </page-commands>
        <page-content>
            <grid [options]="model.options"></grid>
        </page-content>
    </page>
    `
})
export class UserGroups extends BasePage{
    public model: UserGroupsModel;
    constructor(){
        super();
        this.model=new UserGroupsModel(this);
        this.loadUserGroups();
    }
    private loadUserGroups():void{
        let service: IUserGroupService = window.ioc.resolve(IoCNames.IUserGroupService);
        let self=this;
        service.getUserGroups().then((items:Array<any>)=>{
            self.model.options.dataSource.resolve(items);
        });
    }
    public onAddNewUserGroupClicked(ev: any){
        console.log("onAddNewUserGroupClicked");
    }
}