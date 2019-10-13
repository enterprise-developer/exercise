import { IEventManager } from "./ieventManager";
import { IHashable, Hashable } from "../models/ihashable";
import { IValidationResult } from "../models/ivalidationResult";

export class EventManager implements IEventManager {
    private data: IHashable;
    constructor() {
        this.data = new Hashable();
    }
    public subscribe(messageKey: string, handler: (event?: any) => void): void {
        this.data.add(messageKey, handler);
    }

    public publish(validation: IValidationResult): void {
        let handler: any = this.data.get(validation.errorKey);
        if (handler) {
            handler(validation);
        }
    }
}