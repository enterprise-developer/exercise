export interface IValidationResult {
    isValid: boolean;
    errorKey: string;
}

export class ValidationResult implements IValidationResult {
    isValid: boolean;
    errorKey: string;

    constructor(errorKey: string, isValid: boolean) {
        this.errorKey = errorKey;
        this, isValid = isValid;
    }
}