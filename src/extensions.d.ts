declare interface Window {
    ioc: IIoCContainer;
    jQuery: any;
}

declare interface IIoCContainer {
    import(registrations: Array<any>): void;
    resolve(nameOrType: any): any;
    setInjector(injector: any): void;
}

declare interface Array<T> {
    firstOrDefault(predicate: (item: T) => boolean): T;
    removeItem(item: any): Array<T>;
    isEmpty(): boolean;
}

declare interface StringConstructor {
    format(...params: Array<any>): string;

}