export interface IConfigModel {
    domains: Array<IConfigDomain>;
}

export interface IConfigDomain {
    key: string;
    value: string;
}