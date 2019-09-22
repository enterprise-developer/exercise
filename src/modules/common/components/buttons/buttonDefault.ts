import { Component } from "@angular/core";
import { BaseButton } from "./baseButton";
@Component({
    selector: "button-default",
    template: `
    <base-button [text]="text" (onClicked)="onClicked.emit($event)" [cls]="'btn-default'"></base-button>
    `
})
export class ButtonDefault extends BaseButton {

}