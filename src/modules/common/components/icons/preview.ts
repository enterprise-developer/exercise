import { Component } from "@angular/core";
import { BaseIcon } from "./baseIcon";

@Component({
    selector:"icon-preview",
    template:`<base-icon [cls]="'fa-search'" (onClicked)="onClicked.emit($event)" [title]="title" [size]=size ></base-icon> `
})
export class IconPreview extends BaseIcon{
}