import { Component, Output, EventEmitter, Input } from "@angular/core";
import { IconSize } from "../../models/enum";

@Component({
    selector:"base-icon",
    template:`<a (click)="onClicked.emit($event);" href="#"  onclick="return false;" title="{{title}}">
        <i class="fa {{cls}}" [ngClass]="{
            'fa-2x':ENUMS.IconSize.Normal==size,
            'fa-3x':ENUMS.IconSize.Large==size
        }"></i>
    </a>`
})
export class BaseIcon{
    public ENUMS:any={
        IconSize: IconSize
    };
    @Input() size: IconSize = IconSize.Normal;
    @Output() onClicked:EventEmitter<any>=new EventEmitter();
    @Input() title:string;
    @Input() cls:string="";
}