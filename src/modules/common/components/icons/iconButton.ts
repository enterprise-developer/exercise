import { Component, Input, Output, EventEmitter } from "@angular/core";
@Component({
    selector: "icon-button",
    template: `
                <a (click)="onClicked.emit($event)" href="#" onClick="return false;" title="{{text}}">
                    <i class="fa {{cls}}"></i>
                </a>
            `

})
export class IconButton {
    @Input() text: string = "";
    @Input() cls: string = "";
    @Output() onClicked: EventEmitter<any> = new EventEmitter();
}