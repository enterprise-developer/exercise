import {IIoCRegistration, IoCLifecycle} from "../modules/common/enum";
import {ResourceManager} from "../modules/common/services/resourceManager";
let ioc :Array<IIoCRegistration>=[
    { name:"IResourceManager", instanceOf: ResourceManager, lifecycle:IoCLifecycle.Singleton}
];
export default ioc;