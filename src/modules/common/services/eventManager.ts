import { IEventManager } from "./ieventManager";
import { IHashable, Hashable } from "../models/ihashable";
import { IValidationResult } from "../models/ivalidationresult";
export class EventManager implements IEventManager {
    private keys: IHashable;
    constructor() {
        this.keys = new Hashable();
    }
    public subscribe(message: string, handler: (arg: any) => void): void {
        this.keys.add(message, handler);
    }

    public publish(validationResult: IValidationResult): void {
        let handler = this.keys.get(validationResult.messageKey);

        if (handler) {
            handler(validationResult);
        }
    }
}