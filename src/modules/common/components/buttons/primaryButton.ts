import { Component} from "@angular/core";
import {BaseButton} from "./baseButton";
@Component({
    selector:"primary-button",
    template:  `<base-button [cls]="'btn-primary'" [text]="text" (onClicked)="onClicked.emit($event)" ></base-button>`
})
export class PrimaryButton extends BaseButton{
}