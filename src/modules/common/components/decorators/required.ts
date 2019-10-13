import { ValidationState } from "../../models/enums";
import decoratorHelper from "../../helpers/decoratorHelper";

export function required(messageKey: string) {
    return function (target: any, propertyKey: string) {
        target[ValidationState.InvalidState] = target[ValidationState.InvalidState] || [];
        target[ValidationState.InvalidState].push(messageKey);
        return decoratorHelper.define(target, propertyKey, messageKey, isValid);
    }

    function isValid(value: any): boolean {
        return !!value;
    }
}