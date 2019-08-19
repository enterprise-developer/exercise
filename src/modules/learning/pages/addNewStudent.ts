import { Component } from "@angular/core";
import {AddNewStudentModel} from "../models/addNewStudentModel";
@Component({
    template: `
    <page title="i18n.learning.addNewStudent.title">
        <page-content>
            <form-horizontal>
                <form-text-input 
                    [title]="i18n.learning.addNewStudent.firstName" 
                    [validations]="[
                        'learning.addNewStudent.firstNameIsRequired',
                        'learning.addNewStudent.firstNameUnderMinLenght',
                        'learning.addNewStudent.firstNameExcessMaxLenght'
                        ]"
                    [(model)]="model.firstName"
                >
                </form-text-input>
                <form-text-input 
                    [title]="i18n.learning.addNewStudent.lastName" 
                    [validations]="[
                        'learning.addNewStudent.lastNameIsRequired',
                        'learning.addNewStudent.minLenghtExceed',
                        'learning.addNewStudent.maxLenghtExceed'
                        ]"
                    [(model)]="model.lastName"
                >
                </form-text-input>
                <form-text-input 
                    [title]="i18n.learning.addNewStudent.userName" 
                    [validations]="[
                        'learning.addNewStudent.userNameIsRequired',
                        'learning.addNewStudent.minLenghtExceed',
                        'learning.addNewStudent.maxLenghtExceed',
                        'learning.addNewStudent.usernameHasExist'
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
    private model: AddNewStudentModel;

}