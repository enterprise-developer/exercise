import { IValidationResult } from "../models/ivalidationResult";

export interface IEventManager {
    subscribe(messageKe: string, handler: (event?: any) => void): void;
    publish(validation:IValidationResult):void;
}