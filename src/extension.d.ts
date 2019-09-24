interface Window {
    ioc:any; // ioccontainer
}
declare interface Array<T>{
    firstOrDefault(predicate:(item:T)=> boolean):T;
}

declare interface StringConstructor{
    format(...params:Array<any>):string;
}
