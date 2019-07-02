import { IEventManager } from "./ieventManager";
import { IHashtable } from "../models/hash/ihashtable";
import { Hashtable } from "../models/hash/hashtable";

export class EventManager implements IEventManager {
    private keys: IHashtable;
    constructor() {
        this.keys = new Hashtable();
    }
    public subscribe(key: string, handler: (arg: any) => void): void {
        this.keys.add(key, handler);
        //addNewUser.firstWasRequired, ()=>{alert("");}
    }
    public publish(key: string, option?: any): void {
        let handler: any = this.keys.get(key);
        if (!handler) {
            console.log(key + " was not found.");
        }
        handler({ key: key, option: option });
    }
}