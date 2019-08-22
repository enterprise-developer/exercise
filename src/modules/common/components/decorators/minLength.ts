import decoratorHelper from "../../helpers/decoratorHelper";
export function minLength(messageKey: string, minLengthValue: number) {
    return function (target: any, propertyKey: string) {
        return decoratorHelper.defineDecorator(target, propertyKey, messageKey, isValid);
        function isValid(value: string): boolean {
            return !!value && value.length > minLengthValue;
        }
    }
}