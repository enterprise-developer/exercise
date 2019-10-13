import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
    selector: "base-button",
    template: `
        <button type="button" class="btn {{cls}}" (click)="onClicked.emit($event)"></button>
    `
})
export class BaseButton {
    @Input() text: string;
    @Input() cls: string;
    @Output() onClicked: EventEmitter<any> = new EventEmitter();
}