import { IHashtable } from "./ihashtable";

export class Hashtable implements IHashtable{
    private data:any={};
    public add(key:string, value: any):void{
        this.data[key]=value;
    }
    public get(key:string):any{
        return this.data[key];
    }
}