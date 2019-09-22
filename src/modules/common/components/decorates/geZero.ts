import decoratorHelper from "../../helpers/decoratorHelper";

export function geZero(messageKey: string) {
    return function (target: any, propertyKey: string) {
        return decoratorHelper.define(target, propertyKey, messageKey, isValid);
    }
    function isValid(value: string): boolean {
        return !!value && parseInt(value, 10) >= 0;
    }
}