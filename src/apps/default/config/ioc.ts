import { IIoCRegistration } from "@app/common";
import { IoCNames, IoCLifecycle } from "../../../modules/common";
import { ResourceManager } from "../../../modules/common/services/resourceManager";
import { StudentService } from "../../../modules/learning/services/studentService";
import { AppSettingService } from "@app/common";
let registrations: Array<IIoCRegistration> = [
    { name: IoCNames.IResourceManager, instanceOf: ResourceManager, lifecycle: IoCLifecycle.Singleton },
    { name: IoCNames.IStudentService, instanceOf: StudentService, lifecycle: IoCLifecycle.Transient },
    { name: IoCNames.IAppSettingService, instanceOf: AppSettingService, lifecycle: IoCLifecycle.Singleton }
];
export default registrations;