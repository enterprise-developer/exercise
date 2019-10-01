interface Window {
    ioc:any; // ioccontainer
}
declare interface Array<T>{
    firstOrDefault(predicate:(item:T)=> boolean):T;
}

declare interface StringConstructor{
    format(...params:Array<any>):string;
}

declare interface Array<T>{
    removeItem(item:T):Array<T>;
    isEmpty():boolean;
}