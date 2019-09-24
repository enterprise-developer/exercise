///<preference path="extension.d.ts"/>
import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import {AppModule} from "./appModule";
import {IoCContainerFactory} from './modules/common/ioc/iocContainerFactory';
import regs from "./config/ioc";
window.ioc = IoCContainerFactory.create();
window.ioc.import(regs);
platformBrowserDynamic().bootstrapModule(AppModule);
