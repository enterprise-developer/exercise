import { BaseModel, IGridOption, PromiseFactory } from "@app/common";
import { Courses } from "./courses";
export class CoursesModel extends BaseModel {
    public options: IGridOption;
    constructor(page: Courses) {
        super();
        this.options = {
            columns: [
                { field: "name", title: page.i18n.course.courses.name },
                { field: "description", title: page.i18n.course.courses.description }
            ],
            dataSource: PromiseFactory.create(),
            actions: []
        };
    }
}