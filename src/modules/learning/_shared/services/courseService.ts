import { ICourseService } from "./icourseService";
import { IConnector } from "../../../common/connector/iconnector";
import { ConnectorFactory } from "../../../common/connector/connectorFactory";
import { ConnectorType } from "../../../common/enum";
import { Promise } from "../../../common/models/promise";

export class CourseService implements ICourseService{
    public getCourses():Promise{
        let uri:string="/api/learning/courses";
        let connector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        return connector.get(uri);
    }
}