export interface IValidationResult {
    isValid: boolean;
    messageKey: string;
}

export class ValidationResult implements IValidationResult {
    isValid: boolean;
    messageKey: string;
    constructor(messageKey: string, isValid: boolean) {
        this.isValid = isValid;
        this.messageKey = messageKey;
    }
}