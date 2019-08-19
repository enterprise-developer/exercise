import { Directive, Input, AfterContentInit, ElementRef } from "@angular/core";
import { IEventManager } from "../../services/ieventManager";
import { IoCNames, ValidationMessage } from "../../models/enums";
import { IValidationResult } from "../../models/ivalidationResult";
import { BaseComponent } from "../baseComponent";
@Directive({
    selector: '[validations]'
})

export class Validation extends BaseComponent implements AfterContentInit {
    @Input("validations") messages: Array<string> = [];
    private ui: ElementRef;
    public ngAfterContentInit(): void {
        let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
        let self = this;
        this.messages.forEach((message: string) => {
            eventManager.subscribe(message, function (validationResult: IValidationResult) {
                self.onTrigger(validationResult);
            });

        });
    }

    private onTrigger(validationResult: IValidationResult): void {
        if (validationResult.isValid == true) {
            this.ui.nativeElement.classList.remove(ValidationMessage.InvalidState);
            this.ui.nativeElement.title = "";
        } else {
            this.ui.nativeElement.classList.add(ValidationMessage.InvalidState);
            this.ui.nativeElement.title = this.i18nHelper.resolve(validationResult.messageKey);
        }
    }
}

