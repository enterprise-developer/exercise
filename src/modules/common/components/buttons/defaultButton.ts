import { Component} from "@angular/core";
import {BaseButton} from "./baseButton";
@Component({
    selector:"button-default",
    template:  `
    <base-button [cls]="'btn-default'" [text]="text" (onClicked)="onClicked.emit($event)" >
    </base-button>
    `
})
export class DefaultButton extends BaseButton{

}