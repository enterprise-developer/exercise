import { IAppSettingService } from "./iappSettingService";

export class AppSettingService implements IAppSettingService {
    private injector: any;
    private config: any;
    public getInjector(): any {
        return this.injector;
    }
    public setInjector(injector: any): void {
        this.injector = injector;
    }

    public setConfig(config: any): void {
        this.config = config;
    }
    public getConfig(): any {
        return this.config;
    }
}