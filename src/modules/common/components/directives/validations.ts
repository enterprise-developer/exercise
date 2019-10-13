import { Directive, Input, AfterViewInit, ElementRef } from "@angular/core";
import { IEventManager } from "../../event/ieventManager";
import { IoCNames, ValidationState } from "../../models/enums";
import { IValidationResult } from "../../models/ivalidationResult";
import { BaseComponent } from "../baseComponent";

@Directive({
    selector: "[validations]"
})
export class Validations extends BaseComponent implements AfterViewInit {
    @Input("validations") messages: Array<string> = [];

    private ui: ElementRef;

    constructor(el: ElementRef) {
        super();
        this.ui = el;
    }

    public ngAfterViewInit(): void {
        let self = this;
        let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
        this.messages.forEach((mess: string) => {
            eventManager.subscribe(mess, (validation: IValidationResult) => {
                self.onTrigger(validation);
            });
        });
    }

    private onTrigger(validation: IValidationResult): void {
        if (validation.isValid == true) {
            this.ui.nativeElement.classList.remove(ValidationState.InvalidState);
            this.ui.nativeElement.title = "";
        } else {
            this.ui.nativeElement.classList.add(ValidationState.InvalidState);
            this.ui.nativeElement.title = this.i18nHelper.resolve(validation.errorKey);
        }
    }
}