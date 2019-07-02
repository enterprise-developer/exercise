export interface IAppSettingService {
    getInjector(): any;
    setInjector(injector: any): void;
    setConfig(config: any): void;
    getConfig(): any;
}