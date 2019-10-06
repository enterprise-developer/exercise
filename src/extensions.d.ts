declare interface Window {
    ioc: IIoCContainer;
    jQuery: any;
}

declare interface IIoCContainer {
    import(registrations: Array<any>): void;
    resolve(nameOrType: any): any;
    setInjector(setInjector: any): void;
}

declare interface Array<T> {
    firstOrDefault(condition: (item: T) => boolean): T;
    removeItem(item: T): Array<T>;
    isEmpty(): boolean;
}

declare interface StringConstructor {
    format(...args: Array<any>): string;
}