export interface IValidationResult {
    messageKey: string;
    isValid: boolean;
}

export class ValidationResult implements IValidationResult {
    messageKey: string;
    isValid: boolean;
}