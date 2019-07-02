import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
    selector:"form-text-input",
    template:
    `
    <div class="form-group">
        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">{{label}}</label>
        <div class="col-md-6 col-sm-6 col-xs-12">
            <input type="text" name="first-name" (change)="onValueChanged($event)" [(ngModel)]="model" class="form-control col-md-7 col-xs-12">
        </div>
    </div>
    `
})
export class FormTextInput{
    @Input() label:string;
    @Input() model: any;
    // <input>Change
    @Output() modelChange: EventEmitter<any> = new EventEmitter();
    public onValueChanged():void{
        this.modelChange.emit(this.model);
    }
}