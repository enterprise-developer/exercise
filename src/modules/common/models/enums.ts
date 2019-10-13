export interface IIoCRegistration {
    name: string;
    lifecycle: IoCLifecycle;
    instance?: any;
    instanceOf: any;
}

export enum IoCLifecycle {
    Singleton = 1,
    Transient = 2
}

export enum IoCNames {
    IResourceManager = "IResourceManager",
    IProductService = "IProductService",
    IAppSettingService = "IAppSettingService",
    IEventManager ="IEventManager"
}

export enum PromiseStatus {
    Subscribe = 1,
    Success = 2,
    Failed = 3
}

export enum LanguageCode {
    EN = "en"
}

export enum ConnectorType {
    Json = 1
}

export interface IButtonModel {
    text: string;
    cls: string;
    onClicked: (event?: any) => void;
}

export interface IAppConfigModel {
    domains: Array<IDomainConfig>;
}

export interface IDomainConfig {
    key: string;
    value: string;
}

export enum AppConst {
    InventoryUrlApi = "InventoryUrlApi"
}

export enum ValidationState{
    InvalidState ="invalid-state"
}

export enum ProductValidation{
    MinLength = 4,
    MaxLength = 50
}

export enum HttpStatusCode{
    OK = 200
}