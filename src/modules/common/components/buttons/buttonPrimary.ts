import { Component } from "@angular/core";
import { BaseButton } from "./baseButton";
@Component({
    selector: "button-primary",
    template: `
    <base-button [text]="text" (onClicked)="onClicked.emit($event)" [cls]="'btn-primary'"></base-button>
    `
})
export class ButtonPrimary extends BaseButton {

}