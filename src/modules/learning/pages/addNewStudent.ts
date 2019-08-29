import { Component } from "@angular/core";
import {Router} from "@angular/router";
import { AddNewStudentModel } from "../models/addNewStudentModel";
import { IStudentService } from "../services/istudentService";
import { IoCNames } from "@app/common";
@Component({
    template: `
    <page title="i18n.learning.addNewStudent.title">
        <page-content>
            <form-horizontal>
                <form-text-input 
                    [title]="i18n.learning.addNewStudent.firstName" 
                    [validations]="[
                        'learning.addNewStudent.firstNameIsRequired',
                        'learning.addNewStudent.firstNameUnderMinLength',
                        'learning.addNewStudent.firstNameExcessMaxLength'
                        ]"
                    [(model)]="model.firstName"
                >
                </form-text-input>
                <form-text-input 
                    [title]="i18n.learning.addNewStudent.lastName" 
                    [validations]="[
                        'learning.addNewStudent.lastNameIsRequired',
                        'learning.addNewStudent.lastNameUnderMinLength',
                        'learning.addNewStudent.lastNameExcessMaxLength'
                        ]"
                    [(model)]="model.lastName"
                >
                </form-text-input>
                <form-text-input 
                    [title]="i18n.learning.addNewStudent.userName" 
                    [validations]="[
                        'learning.addNewStudent.userNameIsRequired',
                        'learning.addNewStudent.userNameUnderMinLength',
                        'learning.addNewStudent.userNameExcessMaxLength',
                        'learning.addNewStudent.userNameHasExisted'
                        ]"
                    [(model)]="model.userName"
                >
                </form-text-input>

                <form-buttons>
                        <button-primary (onClicked)="onSaveClicked($event)" [text]="i18n.common.save"></button-primary>
                        <button-default (onClicked)="onCancelClicked($event)" [text]="i18n.common.cancel"></button-default>
                </form-buttons>
            </form-horizontal>
        </page-content>
    </page>
    `
})
export class AddNewStudent {
    public model: AddNewStudentModel = new AddNewStudentModel();
    private router:Router;
    
    constructor(router:Router){
        this.router = router;
    }
    
    public onSaveClicked(): void {
        if (!this.model.isValid()) { return; }
        let studentService: IStudentService = window.ioc.resolve(IoCNames.IStudentService);
        let self = this;
        studentService.addNewStudent(this.model).then(() => {
            self.router.navigate(['/learning/students']);
        });
    }

    public onCancelClicked():void{
        this.router.navigate(["/learning/students"]);
    }
}