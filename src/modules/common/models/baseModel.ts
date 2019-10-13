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
        let result: boolean = false;
        let instance: any = this.constructor;
        let messages: Array<string> = instance.prototype.hasOwnProperty(ValidationState.InvalidState) ? instance.prototype[ValidationState.InvalidState] : [];
        result = messages.isEmpty();
        if (!result) {
            let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
            messages.forEach((mess: string) => {
                eventManager.publish(new ValidationResult(mess, false));
            });
        }
        return result;
    }

    public toJSON(): any {
        let result: any = {};
        for (let p in this) {
            if (p.startsWith("_")) {
                let originalKey: string = p.substring(1);
                if (this.hasOwnProperty(originalKey)) {
                    result[originalKey] = this[p];
                }
            } else if (!this.hasOwnProperty(p)) {
                continue;
            }

            result[p] = this[p];
        }
        return result;
    }
}