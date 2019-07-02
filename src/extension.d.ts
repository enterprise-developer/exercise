declare interface IIoCContainer{
    resolve(nameOrType:any):any;
    import(registrations:Array<IIoCRegistration>):void;
}
declare enum IoCLifeCycle{
    Singleton=1,
    Transient=2
}
declare interface IIoCRegistration{
    name:string;
    instanceOf:any;
    lifeCycle: IoCLifeCycle;
    instance?: any;
}
declare interface IReflect{
    getMetadata(name:string, constructor: any):any;
    defineMetadata(name:string, metadata: any, ctor: any):void;
}
declare interface Window{
    ioc: IIoCContainer;
    Reflect:IReflect;
    jQuery:any;
}


declare interface Array<T>{
    firstOrDefault(callback?: any):T;
    remove(item:T):Array<T>;
    isEmpty():boolean;
}
declare interface Object{
    clone():any;
}

declare interface String{
}

declare interface StringConstructor{
    format(...args: Array<any>):string;
    toCamelCase(text:string):string;
}
