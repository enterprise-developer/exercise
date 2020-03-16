import decoratorHelper from "../../helpers/decoratorHelper";
import { ValidationStatus } from "../../models/enums";
export function required(messageKey: string) {
    return function (target: any, propertyKey: string) {
        target[ValidationStatus.InvalidState] = target[ValidationStatus.InvalidState] || [];
        target[ValidationStatus.InvalidState].push(messageKey);
        return decoratorHelper.defineDecorator(target, propertyKey, messageKey, isValid);
        function isValid(value: any): boolean {
            return !!value;
        }
    }
}