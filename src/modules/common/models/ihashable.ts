export interface IHashable {
    add(key: string, value: any): void;
    get(key:string):any;
}

export class Hashable implements IHashable {
    private data: any = {};
    public add(key: string, value: any): void {
        this.data[key] = value;
    }

    public get(key:string):any{
        return this.data[key];
    }
}