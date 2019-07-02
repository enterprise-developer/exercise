import { NgModule, ApplicationRef, Injector } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { HttpModule } from "@angular/http";
import { Routes, RouterModule } from "@angular/router";
import { Layout } from "src/layout";
import { IAppSettingService, IoCNames, IResourceManager } from "@app/common";
import appConfig from "./config/appConfig";
let routes: Routes = [
    { path: "", redirectTo: "userManagement", pathMatch: "full" },
    { path: "userManagement", loadChildren: "/src/modules/userManagement/userModule#UserModule" },
    { path: "course", loadChildren: "/src/modules/course/courseModule#CourseModule" }
];
@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        BrowserModule,
        HttpModule,
        RouterModule.forRoot(routes),
    ],
    exports: [],
    declarations: [Layout],
    entryComponents: [Layout]
})

export class AppModule {
    private appRef: ApplicationRef;

    constructor(appRef: ApplicationRef, injector: Injector) {
        let appSettingService: IAppSettingService = window.ioc.resolve(IoCNames.IAppSettingService);
        appSettingService.setInjector(injector);
        appSettingService.setConfig(appConfig);
        this.appRef = appRef;
    }

    ngDoBootstrap() {
        let self = this;
        let locales: Array<string> = ["common", "users", "addNewUser", "userGroups", "course"];
        let resourceManager: IResourceManager = window.ioc.resolve(IoCNames.IResourceManager);
        resourceManager.load(locales).then(() => {
            self.appRef.bootstrap(Layout);
        });

    }
}