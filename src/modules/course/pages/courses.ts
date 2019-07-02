import { Component } from "@angular/core";
import { BasePage, IoCNames } from "@app/common";
import { CoursesModel } from "./coursesModel";
import {ICourseService} from "../_shared/service/icourseService";
import { Router } from "@angular/router";
@Component({
    template: `
            <page [title]="i18n.course.courses.title">
                <page-commands>
                    <a (click)="onAddNewCourseClicked($event)"><i class="fa fa-plus"></i></a>
                </page-commands>
                <page-content>
                    <grid [options]="model.options"></grid>
                </page-content>
                
            </page>
    `
})

export class Courses extends BasePage {
    public model: CoursesModel;
    constructor(private router:Router) {
        super();
        this.model = new CoursesModel(this);
        this.loadCourses();
    }

    public loadCourses(): void {
        let courseService: ICourseService = window.ioc.resolve(IoCNames.ICourseService);
        let self = this;
        courseService.getCourses().then((courses: Array<any>) => {
            self.model.options.dataSource.resolve(courses);
        });
    }
    public onAddNewCourseClicked(): void { 
        this.router.navigate(["course/addNewCourse"]);
    }
}