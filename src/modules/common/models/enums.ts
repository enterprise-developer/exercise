export class IIoCRegistration {
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
    IResourceService = "IResourceService",
    IProductService = "IProductService",
    IAppSettingService = "IAppSettingService",
    IEventManager = "IEventManager"
}

export enum PromiseStatus {
    Subscribe = 1,
    Success = 2,
    Failed = -1
}

export enum LanguageCode {
    EN = "en"
}

export enum ConnectorType {
    Json = "json",
}

export enum HttpStatusCode {
    OK = 200
}

export enum ValidationState {
    Invalid = "Invalid-State"
}

export enum ProductValidation {
    MinLength = 4,
    MaxLength = 50
}

export enum ProductUrl {
    API = "productUrlApi"
}