import { ValidationState, IoCNames } from "../models/enums";
import { IEventManager } from "../services/ieventManager";
import { ValidationResult } from "../models/ivalidationResult";

let decoratorHelper = {
    define: defineDecorator
}
export default decoratorHelper;
function defineDecorator(target: any, propertyKey: string, messageKey: string, isValid: (value: any) => boolean): void {
    Object.defineProperty(target, propertyKey, {
        get: getFunc,
        set: setFunc
    });

    function getFunc(): void {
        return target[_propertyKey];
    }
    let _propertyKey: string = String.format("_{0}", propertyKey);

    function setFunc(value: any): void {
        target[ValidationState.Invalid] = target[ValidationState.Invalid] || [];
        let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
        if (isValid(value)) {
            eventManager.publish(new ValidationResult(messageKey, true));
            target[ValidationState.Invalid].remove(messageKey);
        } else {
            eventManager.publish(new ValidationResult(messageKey, false));
            target[ValidationState.Invalid].push(messageKey);
        }
        target[_propertyKey] = value;
    }
}