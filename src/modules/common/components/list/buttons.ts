import { Input, Component } from "@angular/core";
import { IButtonModel } from "../../models/enums";
@Component({
    selector: "buttons",
    template: `
    <ul class="nav navbar-right panel_toolbox">
        <li *ngFor="let item of items">
            <icon-button (onClicked)="item.onClicked($event)" [text]="item.text" [cls]="item.cls"></icon-button>
        </li>
    </ul>    
    `
})
export class Buttons {
    @Input() item: Array<IButtonModel>;
}