import { Component, Output, EventEmitter, Input } from "@angular/core";
import { BaseIcon } from "./baseIcon";

@Component({
    selector:"icon-edit",
    template:`<base-icon [cls]="'fa-pencil'" (onClicked)="onClicked.emit($event)" [title]="title" [size]=size ></base-icon> `
})
export class IconEdit extends BaseIcon{
}