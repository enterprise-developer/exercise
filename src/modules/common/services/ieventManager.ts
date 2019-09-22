import { ValidationResult } from "../models/ivalidationResult";
export interface IEventManager {
    subscribe(messageKey: string, handler: (args: any) => void): void;
    publish(result: ValidationResult): void;
}