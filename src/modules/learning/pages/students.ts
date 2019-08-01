import { Component } from "@angular/core";
import { BasePage } from "@app/common";
import { IGridOption } from "../../common/grid/igridOption";
import { PromiseFactory } from "../../common/models/promise";
import { IoCNames } from "../../common";
import {IStudentService} from "../services/istudentService";
@Component({
    template: `
    <page [title]= "i18n.learning.students.title">
        <page-content>
            <grid [options]="model.options">
            </grid>
        </page-content>
    </page>
    `
})
export class Students extends BasePage {
    public model: StudentsModel;
    constructor() {
        super();
        this.model = new StudentsModel(this.i18n);
        let self = this;
        let service: IStudentService = window.ioc.resolve(IoCNames.IStudentService);
        service.getStudents().then((response: Array<StudentsModel>) => {
            self.model.options.data.resolve(response);
        });
    }
}

class StudentsModel {
    public options: IGridOption;
    private i18n: any;
    constructor(i18n: any) {
        this.i18n = i18n;
        this.options = {
            data: PromiseFactory.create(),
            columns: [
                { title: this.i18n.learning.students.firstName, field: "firstName" },
                { title: this.i18n.learning.students.lastName, field: "lastName" },
                { title: this.i18n.learning.students.userName, field: "userName" }
            ]
        };
    }
}