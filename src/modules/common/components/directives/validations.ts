import { Directive, Input, AfterViewInit, ElementRef } from "@angular/core";
import { IoCNames, ValidationState } from "../../models/enums";
import { IEventManager } from "../../services/ieventManager";
import { IValidationResult } from "../../models/ivalidationResult";
import { BaseComponent } from "../../components/baseComponent";
@Directive({
    selector: "validations"
})
export class Validations extends BaseComponent implements AfterViewInit {
    @Input("validations") messages: Array<string> = [];
    private ui: ElementRef;
    constructor(elf: ElementRef) {
        super();
        this.ui = elf;
    }
    public ngAfterViewInit(): void {
        let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
        let self = this;
        this.messages.forEach((message: string) => {
            eventManager.subscribe(message, (validationResult: IValidationResult) => {
                self.onTrigger(validationResult);
            });
        });
    }

    private onTrigger(validationResult: IValidationResult): void {
        if (!validationResult.isValid) {
            this.ui.nativeElement.classList.push(ValidationState.Invalid);
            this.ui.nativeElement.title = this.i18nHelper.resolve(validationResult.messageKey);
        } else {
            this.ui.nativeElement.classList.remove(ValidationState.Invalid);
            this.ui.nativeElement.title = "";
        }
    }
}