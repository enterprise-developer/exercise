import { IEventManager } from "./ieventManager";
import { IHashable, Hashable } from "../models/ihashable";
import { ValidationResult } from "../models/ivalidationResult";

export class EventManager implements IEventManager {
    private keys: IHashable;
    constructor() {
        this.keys = new Hashable();
    }
    subscribe(messageKey: string, handler: (args: any) => void): void {
        this.keys.add(messageKey, handler);
    }

    public publish(result: ValidationResult): void {
        let handler = this.keys.get(result.messageKey);
        if (handler) {
            handler(result);
        }
    }

}