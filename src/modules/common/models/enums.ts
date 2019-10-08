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
    IResourceService = "IResourceService",
    IProductService = "IProductService",
    IAppSettingService = "IAppSettingService"
}
export enum PromiseStatus {
    Subscribe = 1,
    Success = 2
}
export enum LanguageCode {
    EN = "en"
}
export enum ConnectorType {
    Json = "json"
}

export interface IButtonModel {
    onClicked: (event?: any) => void;
    text: string;
    cls: string;
    iconType: IconType
}

export enum IconType {
    AddNew = 1,
    Default = 2
}
export interface IConfigModel {
    domains: Array<IConfigDomain>;
}
export interface IConfigDomain {
    key: string;
    value: string;
}
export interface IResponseModel {
    data: any;
    statusCode: HttpStatusCode;
}
export enum HttpStatusCode {
    OK = 200
}