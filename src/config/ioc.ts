import {IIoCRegistration, IoCLifecycle, IoCNames} from "../modules/common/enum";
import {ResourceManager} from "../modules/common/services/resourceManager";
import {CourseService} from "../modules/learning/_shared/services/courseService";
let ioc :Array<IIoCRegistration>=[
    { name:IoCNames.IResourceManager, instanceOf: ResourceManager, lifecycle:IoCLifecycle.Singleton},
    {name: IoCNames.ICourseService, instanceOf: CourseService, lifecycle: IoCLifecycle.Transient}
];
export default ioc;