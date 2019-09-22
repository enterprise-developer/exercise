import decoratorHelper from "../../helpers/decoratorHelper";

export function minLength(messageKey: string, min: number) {
    return function (target: any, propertyKey: string) {
        return decoratorHelper.define(target, propertyKey, messageKey, isValid);
    }
    function isValid(value: string): boolean {
        return !!value && value.length >= min;
    }
}