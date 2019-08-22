
export interface IIoCRegistration {
    name: string;
    lifecycle: IoCLifecycle;
    instance?: any;
    instanceOf: any;
}

export enum IoCLifecycle {
    Singleton = 1,
    Transient = 2,
}

export enum IoCNames {
    IResourceManager = "IResourceManager",
    IConnector = "IConnector",
    IStudentService = "IStudentService",
    IAppSettingService = "IAppSettingService",
    IEventManager = "IEventManager"
}


export enum PromiseStatus {
    Subscribe = 1,
    Success = 2,
    Failed = 3
}

export enum LanguageCodes {
    EN = "en",
}

export enum ConnectorType {
    Json = 1
}

export interface IConfigDomain {
    key: string;
    value: string;
}


export interface IConfigModel {
    domains: Array<IConfigDomain>;
}

export enum HttpStatusCode {
    OK = 200
}

export interface IButtonModel {
    onClicked: (event?: any) => void;
    text: string;
    cls: string;
}

export enum ValidationMessage {
    InvalidState = "invalid-state"
}
export enum ValidationStatus {
    InvalidState = "invalid"
}