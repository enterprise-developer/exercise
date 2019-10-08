/// <reference path="./extendsions.d.ts" />
import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { AppModule } from "./app/appModule";
import { IoCFactory } from "@app/common";
import registrations from "./app/default/config/ioc";
let iocContainer: IIoCContainer = IoCFactory.create();
iocContainer.import(registrations);
window.ioc = iocContainer;
platformBrowserDynamic().bootstrapModule(AppModule);