import {
    IIoCRegistration, IoCNames, IoCLifecycle, ResourceManager, ProductService,
    AppSettingService, EventManager
} from "@app/common";


let registrations: Array<IIoCRegistration> = [
    { name: IoCNames.IResourceManager, instanceOf: ResourceManager, lifecycle: IoCLifecycle.Singleton },
    { name: IoCNames.IProductService, instanceOf: ProductService, lifecycle: IoCLifecycle.Transient },
    { name: IoCNames.IAppSettingService, instanceOf: AppSettingService, lifecycle: IoCLifecycle.Singleton },
    { name: IoCNames.IEventManager, instanceOf: EventManager, lifecycle: IoCLifecycle.Singleton }
];
export default registrations;