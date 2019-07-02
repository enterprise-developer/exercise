import { Component} from "@angular/core";
import {BasePage} from "@app/common";
import {IUserService} from "../_shared/services/iuserService";
import {IoCNames} from "@app/common";
import { Router } from "@angular/router";
import {UsersModel} from "./usersModel";
@Component({
    template:`
    <page [title]="i18n.users.title">
        <page-commands>
            <a (click)="onAddNewserClicked($event)"><i class="fa fa-plus"></i></a>
        </page-commands>
        <page-content>
            <grid [options]="model.options"></grid>
        </page-content>
    </page>
    `
})
export class Users extends BasePage{
    private router:Router;
    public model: UsersModel;
    constructor(router: Router){
        super();
        let self=this;
        self.model=new UsersModel(this);
        self.router=router;
        let userService: IUserService= window.ioc.resolve(IoCNames.IUserService);
        userService.getUsers().then((users: Array<any>)=>{
            self.model.options.dataSource.resolve(users);
        });
    }
    public onAddNewserClicked():void{
        this.router.navigate(["userManagement/addNewUser"]);
    }
    public onEditUserClicked(user: any):void{
        console.log(user);
    }

    public onDeleteUserClicked(user: any):void{
        console.log(user);
    }

    public onInActiveUserClicked(user: any):void{
        console.log(user);
    }

    public onActiveUserClicked(user: any):void{
        console.log(user);
    }
}