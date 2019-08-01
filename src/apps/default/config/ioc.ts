import { IIoCRegistration } from "@app/common";
import { IoCNames, IoCLifecycle } from "../../../modules/common";
import { ResourceManager } from "../../../modules/common/services/resourceManager";
import {StudentService} from "../../../modules/learning/services/studentService";
let registrations: Array<IIoCRegistration> = [
    { name: IoCNames.IResourceManager, instanceOf: ResourceManager, lifecycle: IoCLifecycle.Singleton },
    { name: IoCNames.IStudentService, instanceOf: StudentService, lifecycle: IoCLifecycle.Transient }
];
export default registrations;