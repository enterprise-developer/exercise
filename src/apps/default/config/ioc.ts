import { IIoCRegistration } from "@app/common";
import { IoCNames, IoCLifecycle } from "../../../modules/common";
import { ResourceManager } from "../../../modules/common/services/resourceManager";
let registrations: Array<IIoCRegistration> = [
    { name: IoCNames.IResourceManager, instanceOf: ResourceManager, lifecycle: IoCLifecycle.Singleton }
    
];
export default registrations;