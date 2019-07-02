import { UserService } from "../services/userService";
import { AppSettingService } from "@app/common";
import { IoCNames, IoCLifeCycle } from "@app/common";
import { JSONConnector } from "@app/common";
import { ResourceManager } from "@app/common";
import { EventManager } from "@app/common";
import { UserGroupService } from "../services/userGroupService";
import { CourseService } from "../../../course/_shared/service/courseService";
let registrations: Array<IIoCRegistration> = [
    { name: IoCNames.IUserService, instanceOf: UserService, lifeCycle: IoCLifeCycle.Transient },
    { name: IoCNames.IAppSettingService, instanceOf: AppSettingService, lifeCycle: IoCLifeCycle.Singleton },
    { name: IoCNames.IConnector, instanceOf: JSONConnector, lifeCycle: IoCLifeCycle.Transient },
    { name: IoCNames.IResourceManager, instanceOf: ResourceManager, lifeCycle: IoCLifeCycle.Singleton },
    { name: IoCNames.IEventManager, instanceOf: EventManager, lifeCycle: IoCLifeCycle.Singleton },
    { name: IoCNames.IUserGroupService, instanceOf: UserGroupService, lifeCycle: IoCLifeCycle.Transient },
    { name: IoCNames.ICourseService, instanceOf: CourseService, lifeCycle: IoCLifeCycle.Transient }
];
export default registrations;