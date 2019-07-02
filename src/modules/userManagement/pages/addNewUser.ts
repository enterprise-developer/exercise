import { Router } from "@angular/router";
import { Component } from "@angular/core";
import { BasePage } from "@app/common";
import { IoCNames } from "@app/common";
import {AddNewUserModel} from "./addNewUserModel";
import { IUserService } from "../_shared/services/iuserService";
@Component({
    template:`
    <page [title]="i18n.addNewUser.title">
    <page-content>
        <form-horizontal>
            <form-text-input
                [validation]="['addNewUser.firstNameWasRequired']"
                [label]="i18n.addNewUser.firstName" 
                [(model)]="model.firstName"
            ></form-text-input>
            <form-text-input
                [validation]="['addNewUser.lastNameWasRequired']"
                [label]="i18n.addNewUser.lastName" 
                [(model)]="model.lastName"
            ></form-text-input>
            <form-text-input [label]="i18n.addNewUser.userName" 
            [(model)]="model.userName"
            [validation]="['addNewUser.userNameWasUsed']"></form-text-input>
            <form-buttons>
                <button type="button" class="btn btn-primary" (click)="onSaveClicked($event)">{{i18n.common.form.save}}</button>
                <button type="button" class="btn btn-default" (click)="onCancelClicked($event)">{{i18n.common.form.cancel}}</button>
            </form-buttons>
        </form-horizontal>
    </page-content>
  </page>
    
    `
})
export class AddNewUser extends BasePage{
    public model: AddNewUserModel;
    private router:Router;
    constructor(router: Router){
        super();
        this.router = router;
        this.model=new AddNewUserModel();
    }
    public onSaveClicked():void{
        if(!this.model.isValid()){return;}
        let service : IUserService = window.ioc.resolve(IoCNames.IUserService);
        let self=this;
        service.createUser(this.model).then(()=>{
            self.router.navigate(["userManagement/users"]);
        });
    }
    public onCancelClicked():void{
        this.router.navigate(["userManagement/users"]);
    }
}