import decoratorHelper from "../../helpers/decoratorHelper"

export function geZero(messageKey: string) {
    return function (target: any, propertykey: string) {
        return decoratorHelper.define(target, propertykey, messageKey, isValid);
    }

    function isValid(value: any): boolean {
        return !!value && parseInt(value) >= 0;
    }
}