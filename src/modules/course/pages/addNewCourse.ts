import { BaseComponent } from "src/modules/common/models/baseComponent";
import { Component } from "@angular/core";
import { AddNewCourseModel } from "./addNewCourseModel";
import { ICourseService } from "../_shared/service/icourseService";
import { IoCNames } from "@app/common";
import { Router } from "@angular/router";
@Component({
    template: `
    <page [title]="i18n.course.addNewCourse.title">
    <page-content>
        <form-horizontal>
            <form-text-input
                [label]="i18n.course.addNewCourse.name" 
                [(model)]="model.name"
            ></form-text-input>

            <form-text-input
                [label]="i18n.course.addNewCourse.description" 
                [(model)]="model.description"
            ></form-text-input>

            <form-text-input
                [label]="i18n.course.addNewCourse.author.firstName" 
                [(model)]="model.author.firstName"
            ></form-text-input>

            <form-text-input
                [label]="i18n.course.addNewCourse.author.lastName" 
                [(model)]="model.author.lastName"
            ></form-text-input>

            <form-text-input [label]="i18n.course.addNewCourse.author.userName" 
            [(model)]="model.author.userName">
            </form-text-input>

            <form-buttons>
                <button type="button" class="btn btn-primary" (click)="onSaveClicked($event)">{{i18n.common.form.save}}</button>
                <button type="button" class="btn btn-default" (click)="onCancelClicked($event)">{{i18n.common.form.cancel}}</button>
            </form-buttons>
        </form-horizontal>
    </page-content>
  </page>`

})
export class AddNewCourse extends BaseComponent {
    public model: AddNewCourseModel = new AddNewCourseModel();
    private router: Router;
    constructor(router: Router) {
        super();
        this.router = router;
    }

    public onSaveClicked(): void {
        let courseService: ICourseService = window.ioc.resolve(IoCNames.ICourseService);
        let self = this;
        courseService.createCourse(this.model).then(() => {
            self.router.navigate(["course/courses"]);
        });
    }

    public onCancelClicked(): void {
        this.router.navigate(["course/courses"]);
    }
}