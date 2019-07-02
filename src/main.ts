///<preference path="./extension.d.ts" /> 
import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { IoCFactory } from "./modules/common/ioc/iocFactory";
import registrations from "./modules/userManagement/_shared/config/ioc";
import { AppModule } from "./app/appModule";
let iocContainer: IIoCContainer = IoCFactory.create();
iocContainer.import(registrations);
window.ioc = iocContainer;
platformBrowserDynamic().bootstrapModule(AppModule).then((module: any) => {
});