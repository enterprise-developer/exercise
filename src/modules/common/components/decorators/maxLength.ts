import decoratorHelper from "../../helpers/decoratorHelper"

export function maxLength(messageKey: string, max: number) {
    return function (target: any, propertyKey: string) {
        return decoratorHelper.define(target, propertyKey, messageKey, isValid);
    }

    function isValid(value: any): boolean {
        return !!value && value.length <= max;
    }
}