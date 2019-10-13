import { Component } from "@angular/core";
import { BaseButton } from "./baseButton";

@Component({
    selector: "button-primary",
    template: `
        <base-button [text]="text" [cls]="'btn-primary'" (onClicked)="onClicked.emit($event)"></base-button>
    `
})
export class ButtonPrimary extends BaseButton {

}