import { ValidationState, IoCNames } from "../models/enums";
import { IEventManager } from "../event/ieventManager";
import { ValidationResult } from "../models/ivalidationResult";

let decoratorHelper: any = {
    define: define
}
export default decoratorHelper;

function define(target: any, propertyKey: string, messagekey: string, isValid: (value: any) => boolean): void {
    let _propertyKey = String.format("_{0}", propertyKey);
    function getFunc() {
        return target[_propertyKey];
    }

    function setFunc(value: any) {
        target[_propertyKey] = value;
        target[ValidationState.InvalidState] = target[ValidationState.InvalidState] || [];
        let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
        if (isValid(value) == false) {
            target[ValidationState.InvalidState].push(messagekey);
            eventManager.publish(new ValidationResult(messagekey, false));
        } else {
            target[ValidationState.InvalidState] = target[ValidationState.InvalidState].removeItem(messagekey);
            eventManager.publish(new ValidationResult(messagekey, true));
        }
    }
    Object.defineProperty(target, propertyKey, {
        get: getFunc,
        set: setFunc
    });
}