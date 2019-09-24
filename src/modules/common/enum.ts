export interface IIoCRegistration{
    name:string;
    lifecycle: IoCLifecycle;
    instanceOf: any;
    instance?:any;
}
export enum IoCLifecycle{
    Transient=1,
    Singleton=2
}