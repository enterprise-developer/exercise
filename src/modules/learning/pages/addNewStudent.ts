import { Component } from "@angular/core";
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
                        <button-primary (onClicked)="onSaveClicked($event)" [title]="i18n.learning.addNewStudent.save"></button-primary>
                        <button-default (onClicked)="onCancelClicked($event)" [title]="i18n.learning.addNewStudent.cancel"></button-default>
                </form-buttons>
            </form-horizontal>
        </page-content>
    </page>
    `
})
export class AddNewStudent {
    public model: AddNewStudentModel = new AddNewStudentModel();
    public onSaveClicked(): void {
        if (!this.model.isValid()) { return; }
        let studentService: IStudentService = window.ioc.resolve(IoCNames.IStudentService);
        studentService.addNewStudent(this.model).then(() => {
            self.router.navigate(['/users']);
        });
    }
}