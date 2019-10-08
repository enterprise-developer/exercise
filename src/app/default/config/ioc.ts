import { IIoCRegistration } from "@app/common";
import { IoCNames, IoCLifecycle, ResourceService, AppSettingService } from "@app/common";
import { ProductService } from "../../../modules/inventory/services/productService";
let registrations: Array<IIoCRegistration> = [
    { name: IoCNames.IResourceService, lifecycle: IoCLifecycle.Singleton, instanceOf: ResourceService },
    { name: IoCNames.IProductService, lifecycle: IoCLifecycle.Transient, instanceOf: ProductService },
    { name: IoCNames.IAppSettingService, lifecycle: IoCLifecycle.Singleton, instanceOf: AppSettingService },
];
export default registrations;