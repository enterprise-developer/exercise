
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
    IConnector = "IConnector"
}


export enum PromiseStatus {
    Subscribe = 1,
    Success = 2
}

export enum LanguageCodes {
    EN = "en",
}

export enum ConnectorType {
    Json = 1
}