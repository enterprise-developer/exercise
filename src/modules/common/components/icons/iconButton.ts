import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
    selector: "icon-button",
    template: `
        <a href="#" onClick="return false;" title="{{text}}" (click)="onClicked.emit($event)">
            <i class ="fa fa-{{cls}}"></i>
        </a>
    `
})
export class IconButton {
    @Input() text: string;
    @Input() cls: string;
    @Output() onClicked: EventEmitter<any> = new EventEmitter();
}