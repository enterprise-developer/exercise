import { IButtonModel, ValidationState, IoCNames } from "./enums";
import { IEventManager } from "../event/ieventManager";
import { ValidationResult } from "./ivalidationResult";

export class BaseModel {
    public buttons: Array<IButtonModel> = [];
    public addButton(text: string, cls: string, handler: (event?: any) => void): void {
        this.buttons.push({
            text: text,
            cls: cls,
            onClicked: handler
        });
    }

    public isValid(): boolean {
        let valid: boolean = false;
        let instance: any = this.constructor;
        let messages: Array<string> = instance.prototype.hasOwnProperty(ValidationState.InvalidState) ? instance.prototype[ValidationState.InvalidState] : [];
        valid = messages.isEmpty();
        if (valid == false) {
            let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
            messages.forEach((mess: string) => {
                eventManager.publish(new ValidationResult(mess, false));
            });
        }
        return valid;
    }

    public toJson(): any {
        let result: any = {};
        for (let p in this) {
            if (p.startsWith("_")) {
                let originKey = p.substring(1);
                if (this.hasOwnProperty(originKey)) {
                    result[originKey] = this[p];
                }
            } else if (!this.hasOwnProperty(p)) {
                continue;
            }
            result[p] = this[p];
        }
        return result;
    }
}