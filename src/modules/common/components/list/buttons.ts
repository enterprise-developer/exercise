import { Component, Input } from "@angular/core";
import {IButtonModel} from "../../models/enums";

@Component({
    selector: "buttons",
    template: `
    <ul class="nav navbar-right panel_toolbox">
        <li *ngFor="let item of items">
            <icon-button [text]="item.text" [cls]="item.cls" (onClicked)="item.onClicked($event)">
            </icon-button>
        </li>
    </ul>
    `
})
export class Buttons {
    @Input() items: Array<IButtonModel>;
}