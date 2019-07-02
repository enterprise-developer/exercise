import { BaseModel } from "@app/common";

export class AddNewCourseModel extends BaseModel {
    public name: string;
    public description: string;
    public author: AuthorModel;

    constructor() {
        super();
        this.author = new AuthorModel();
    }
}

class AuthorModel {
    public firstName: string;
    public lastName: string;
    public userName: string;
}