import { ValidationStatus } from "./enums";

export class BaseModel {
    public isValid(): boolean {
        return this.hasOwnProperty(ValidationStatus.InvalidState)
            ? this[ValidationStatus.InvalidState].isEmpty() : true;
    }
}