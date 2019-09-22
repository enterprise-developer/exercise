import { NgModule, Injector, ApplicationRef } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { AppRoutes } from "./appRoutes";
import { Layout } from "./layout";
import appConfig from "./app/default/appConfig";
import { IResourceService, IoCNames, IAppSettingService } from "@app/common";
import { HttpModule } from "@angular/http";
import { CommonModule } from "@angular/common";
@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        AppRoutes,
        FormsModule,
        HttpModule,
        CommonModule
    ],
    declarations: [Layout]
})
export class AppModule {
    private appRef: ApplicationRef;

    constructor(injector: Injector, appRef: ApplicationRef) {
        window.ioc.setInjector(injector);
        this.appRef = appRef;
        let appSettingService: IAppSettingService = window.ioc.resolve(IoCNames.IAppSettingService);
        appSettingService.setConfig(appConfig);
    }
    ngDoBootstrap() {
        let resourceService: IResourceService = window.ioc.resolve(IoCNames.IResourceService);
        let locales: Array<string> = ["business","common"];
        let self = this;
        resourceService.loadLocales(locales).then(() => {
            self.appRef.bootstrap(Layout);
        });
    }
}