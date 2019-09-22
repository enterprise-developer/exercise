export interface IHashable {
    add(key: string, value: any): void;
    get(keu: string): any;
}

export class Hashable implements IHashable {
    private data: any = {};
    public add(key: string, value: string): void {
        this.data[key] = value;
    }

    public get(key: string): any {
        return this.data[key];
    }
}