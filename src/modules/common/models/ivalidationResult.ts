export interface IValidationResult {
    messageKey: string;
    isValid: boolean;
}

export class ValidationResult implements IValidationResult {
    messageKey: string;
    isValid: boolean;
    constructor(messageKey: string, isValid: boolean) {
        this.messageKey = messageKey;
        this.isValid = isValid;
     }
}