import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
    selector:"base-button",
    template:`
    <button type="button" class ="btn {{cls}}" (click)="onClicked.emit($event)">{{text}}</button>
    `
})
export class BaseButton{
@Input() cls:string;
@Input() text:string;
@Output() onClicked:EventEmitter<any> = new EventEmitter();
}