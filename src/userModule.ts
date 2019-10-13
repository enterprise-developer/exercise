import { NgModule, Injector, ApplicationRef } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { UserRoutes } from "./userRoutes";
import { Layout } from "./layout";
import { IoCNames, IResourceManager, IAppSettingService } from "@app/common";
import appConfig from "./apps/default/appConfig";
import { HttpModule } from "@angular/http";

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        UserRoutes,
        HttpModule
    ],
    declarations: [Layout],
    entryComponents: [Layout]
})
export class UserModule {
    private appRef: ApplicationRef;
    constructor(injector: Injector, appRef: ApplicationRef) {
        window.ioc.setInjector(injector);
        this.appRef = appRef;
        let appSettingService: IAppSettingService = window.ioc.resolve(IoCNames.IAppSettingService);
        appSettingService.setConfig(appConfig);
    }

    ngDoBootstrap() {
        let locales: Array<string> = ["inventory", "common"];
        let self = this;
        let resourceManager: IResourceManager = window.ioc.resolve(IoCNames.IResourceManager);
        resourceManager.loadLocale(locales).then(() => {
            self.appRef.bootstrap(Layout);
        });
    }
}