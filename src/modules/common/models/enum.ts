export const IoCNames={
    IUserService:"IUserService",
    IAppSettingService: "IAppSettingService",
    IConnector:"IConnector",
    IResourceManager:"IResourceManager",
    IEventManager:"IEventManager",
    IUserGroupService:"IUserGroupService",
    ICourseService: "ICourseService"
};
export enum IoCLifeCycle{
    Singleton=1,
    Transient=2
}

export enum IconSize{
    Small=1,
    Normal=2,
    Large=3
}
export  const LanguageCode={
    EN:"en",
    VN:"vn"
};

export const ValidationConst={
    ValidationProperty:"__validationResult"
};

export const ClassConst={
    Metadata:"__metadata"
};
export const ValidationStatus={
    Success:1
}

export interface IEventArg{
    key:string;
    option:any;
}

export enum HttpStatusCode{
    OK=200,
    BadRequest=400
}