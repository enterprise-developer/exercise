import { IValidationResult } from "../models/ivalidationResult";

export interface IEventManager {
    subscribe(messageKey: string, handler: (event?: any) => void): void;
    publish(validation: IValidationResult): void;
}