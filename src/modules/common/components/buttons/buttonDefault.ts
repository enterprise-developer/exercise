import { Component } from "@angular/core";
import { BaseButton } from "./baseButton";

@Component({
    selector:"button-default",
    template:`
        <base-button [text]="text" cls="'btn-default'" (onClicked)="onClicked.emit($event)"></base-button>
    `
})
export class ButtonDefault extends BaseButton{
    
}