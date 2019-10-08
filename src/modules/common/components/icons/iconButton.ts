import { Output, EventEmitter, Input, Component } from "@angular/core";
@Component({
    selector: "icon-button",
    template: `
        <a (click)="onClicked.emit(#event)" href="#" onClick="return false;" title="{{text}}"></a>
    `
})
export class IconButton {
    @Output() onClicked: EventEmitter<any> = new EventEmitter();
    @Input() text: string = "";
    @Input() cls: string = "fa-plus";
}