import { Component } from "@angular/core";
import { BasePage, IButtonModel } from "@app/common";
import { IGridOption } from "../../common/components/grid/igridOption";
import { PromiseFactory } from "../../common/models/promise";
import { IoCNames } from "../../common";
import { IStudentService } from "../services/istudentService";
import { Router } from "@angular/router";
@Component({
    template: `
    <page [title]= "i18n.learning.students.title">
        <page-command>
            <buttons [items]="model.buttons"></buttons>
        </page-command>    
        <page-content>
            <grid [options]="model.options">
            </grid>
        </page-content>
    </page>
    `
})
export class Students extends BasePage {
    public model: StudentsModel;
    private router: Router;
    constructor(router: Router) {
        super();
        this.model = new StudentsModel(this.i18n);
        this.router = router;
        let self = this;
        let service: IStudentService = window.ioc.resolve(IoCNames.IStudentService);
        service.getStudents().then((response: Array<StudentsModel>) => {
            self.model.options.data.resolve(response);
        });
        this.model.addButton(this.i18n.learning.students.addNew, "fa-plus", this.onAddNewClicked);
    }

    public onAddNewClicked(): void {
        this.router.navigate(["learning/students/addNew"]);
    }
}

class StudentsModel {
    public options: IGridOption;
    private i18n: any;
    public buttons: Array<IButtonModel> = [];
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

    public addButton(title: string, cls: string, handler: (event?: any) => void): void {
        this.buttons.push({
            text: title,
            cls: cls,
            onClicked: handler
        });
    }

}