import { NgModule, Injector, ApplicationRef } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { Layout } from "./layout";
import { RouterModule } from "@angular/router";
import { AppRoutes } from "./appRoutes";
import { IResourceManager } from "./modules/common/services/iresourceManager";
import { IoCNames } from "./modules/common";
import { IAppSettingService } from "@app/common";
import appConfig from "./apps/default/appConfig";
@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        RouterModule,
        AppRoutes
    ],
    declarations: [Layout]

})
export class AppModule {
    private appRef: ApplicationRef;
    constructor(injector: Injector, appRef: ApplicationRef) {
        window.ioc.setInjector(injector);
        this.appRef = appRef;
        let service: IAppSettingService = window.ioc.resolve(IoCNames.IAppSettingService);
        service.setConfig(appConfig);
    }

    ngDoBootstrap() {
        let locales: Array<string> = ['learning'];
        let resourceManager: IResourceManager = window.ioc.resolve(IoCNames.IResourceManager);
        let self = this;
        resourceManager.loadLocales(locales).then(() => {
            self.appRef.bootstrap(Layout);
        });
    }

}