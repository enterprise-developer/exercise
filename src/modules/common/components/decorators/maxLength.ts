import decoratorHelper from "../../helpers/decoratorHelper";

export function maxLength(messageKey: string, maxLengthValue: number) {
    return function (target: any, propertyKey: string) {
        return decoratorHelper.defineDecorator(target, propertyKey, messageKey, isValid);
        function isValid(value: string): boolean { 
            return !!value && value.length < maxLengthValue;
        }
    }
}