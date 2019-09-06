import { IStudentService } from "./istudentService";
import { Promise } from "@app/common";
import { IConnector, ConnectorFactory, ConnectorType } from "@app/common";
import { BaseService } from "@app/common";
import { LearningConst } from "../enums";
import { AddNewStudentModel } from "../models/addNewStudentModel";
export class StudentService extends BaseService implements IStudentService {
    constructor() {
        super(LearningConst.UrlApi);
    }
    public getStudents(): Promise {
        let url: string = "/students";
        let connector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        return connector.get(this.resolveUrl(url));
    }
    public addNewStudent(item: AddNewStudentModel): Promise {
        let url: string = "/students";
        let connector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        return connector.post(this.resolveUrl(url), item);
    }
}