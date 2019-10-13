export interface IValidationResult {
    isValid: boolean;
    errorKey: string;
}

export class ValidationResult implements IValidationResult {
    isValid: boolean;
    errorKey: string;
    constructor(messageKey: string, valid: boolean) {
        this.errorKey = messageKey;
        this.isValid = valid;
    }
}