import { IEventManager } from "../../services/ieventManager";
import { IoCNames } from "../../models/enums";
import { ValidationResult } from "../../models/ivalidationResult";
export function required(errorKey: string) {
    return function (target: string, propertyKey: string) {

        let setFunc = function (val: any) {
            target[propertyKey] = val;
            let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
            if (!val) {
                let validationResult = new ValidationResult();
                validationResult.isValid = false;
                validationResult.messageKey = errorKey;
                eventManager.publish(validationResult);
            }
        }
        let getFunc = function () {
            return target[propertyKey];
        }

        Object.defineProperty(target, propertyKey, {
            get: getFunc,
            set: setFunc
        });
    }
}