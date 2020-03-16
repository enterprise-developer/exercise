import { IEventManager } from "../services/ieventManager";
import { IoCNames } from "../models/enums";
import { ValidationResult } from "../models/ivalidationResult";
import { ValidationStatus } from "../models/enums";

let decoratorHelper = {
    defineDecorator: defineDecorator
}
export default decoratorHelper;

function defineDecorator(target: any, propertyKey: string, messageKey: string, isValid: (value: string) => boolean) {
    let _propertyKey: string = String.format("_{0}", propertyKey);
    function setFunc(value: any) {
        let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
        target[ValidationStatus.InvalidState] = target[ValidationStatus.InvalidState] || [];
        if (isValid(value) == false) {
            eventManager.publish(new ValidationResult(messageKey, false));
            target[ValidationStatus.InvalidState].push(messageKey);
        } else {
            eventManager.publish(new ValidationResult(messageKey, true));
            target[ValidationStatus.InvalidState].removeItem(messageKey);
        }
        target[_propertyKey] = value;
    }
    function getFunc() {
        return target[_propertyKey];
    }

    Object.defineProperty(target, propertyKey, {
        get: getFunc,
        set: setFunc
    });
}