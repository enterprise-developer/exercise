import { ValidationState } from "./enums";

export class BaseModel {
    public isValid(): boolean {
        return this.hasOwnProperty(ValidationState.Invalid) ? this[ValidationState.Invalid].isEmpty() : true;
    }
}