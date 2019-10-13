import { ValidationState, IoCNames } from "../models/enums";
import { IEventManager } from "../event/ieventManager";
import { ValidationResult } from "../models/ivalidationResult";

let decoratorHelper: any = {
    define: define
};
export default decoratorHelper;

function define(target: any, propertykey: string, messageKey: string, isValid: (value: any) => boolean) {
    let _propertyKey: string = String.format("_{0}", propertykey);

    function getFunc() {
        return target[_propertyKey];
    }

    function setFunc(value: any) {
        target[ValidationState.InvalidState] = target[ValidationState.InvalidState] || [];
        target[_propertyKey] = value;
        let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
        if (isValid(value) == false) {
            target[ValidationState.InvalidState].push(messageKey);
            eventManager.publish(new ValidationResult(messageKey, false));
        } else {
            target[ValidationState.InvalidState] = target[ValidationState.InvalidState].removeItem(messageKey);
            eventManager.publish(new ValidationResult(messageKey, true));
        }

    }

    Object.defineProperty(target, propertykey, {
        get: getFunc,
        set: setFunc
    });
}