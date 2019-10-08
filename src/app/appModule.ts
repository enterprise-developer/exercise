import { NgModule, Injector, ApplicationRef } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { Layout } from "../layout";
import { AppRoutes } from "./appRoutes";
import { IResourceService, IAppSettingService, IoCNames } from "@app/common";
import { HttpModule } from "@angular/http";
import appConfig from "./default/config/appConfig";
@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        AppRoutes,
        HttpModule,
    ],
    declarations: [Layout]
})
export class AppModule {
    private appRef: ApplicationRef;
    constructor(injector: Injector, appRef: ApplicationRef) {
        window.ioc.setInjector(injector);
        this.appRef = appRef;
        let appSettingService : IAppSettingService = window.ioc.resolve(IoCNames.IAppSettingService);
        appSettingService.setConfig(appConfig);
    }
    ngDoBootstrap() {
        let locales: Array<string> = ['inventory'];
        let resourceService: IResourceService = window.ioc.resolve(IoCNames.IResourceService);
        let self = this;
        resourceService.loadLocales(locales).then(() => {
            self.appRef.bootstrap(Layout);
        });
    }
}