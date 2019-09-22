import { IIoCRegistration, IoCNames, IoCLifecycle } from "@app/common";
import { ResourceService } from "@app/common";
import { ProductService } from "../../../modules/business/services/productService";
import { AppSettingService, EventManager } from "@app/common";
let registrations: Array<IIoCRegistration> = [
    { name: IoCNames.IResourceService, instanceOf: ResourceService, lifecycle: IoCLifecycle.Singleton },
    { name: IoCNames.IProductService, instanceOf: ProductService, lifecycle: IoCLifecycle.Transient },
    { name: IoCNames.IAppSettingService, instanceOf: AppSettingService, lifecycle: IoCLifecycle.Singleton },
    { name: IoCNames.IEventManager, instanceOf: EventManager, lifecycle: IoCLifecycle.Singleton }
];

export default registrations;