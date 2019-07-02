import { Promise, IConnector, IoCNames } from "@app/common";
import { BaseService } from "../../../common/models/baseService";
export class CourseService extends BaseService {
    constructor() {
        super("TINYERP.COURSE.API_ENDPOINT");
    }
    public getCourses(): Promise {
        let url: string = "/courses";
        let connector: IConnector = window.ioc.resolve(IoCNames.IConnector);
        return connector.get(this.resolve(url));
    }

    public createCourse(model: any): Promise {
        let url: string = "/courses";
        let connector: IConnector = window.ioc.resolve(IoCNames.IConnector);
        return connector.post(this.resolve(url), model);
    }
} 