import { IStudentService } from "./istudentService";
import { Promise } from "@app/common";
import { IConnector, ConnectorFactory, ConnectorType } from "@app/common";
import { IoCNames } from "../../common";
export class StudentService implements IStudentService {
    private domainName: string;
    constructor() {
        let service: IAppSettingService = window.ioc.resolve(IoCNames.IAppSettingService);
    }
    public getStudents(): Promise {
        let url: string = "/students";
        let connector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        return connector.get(url);
    }
}