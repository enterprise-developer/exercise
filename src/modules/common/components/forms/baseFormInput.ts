import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
    selector: "base-form-input",
    template: `
    <div class="form-group">
        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">{{title}}
        </label>
        <div class="col-md-6 col-sm-6 col-xs-12" [ngSwitch]="formInputType">
            <input *ngSwitchCase="'text'" type="text" id="first-name" required="required" class="form-control col-md-7 col-xs-12"
            [(ngModel)]="model" (change)="onModelChange($event)">
            
            <input *ngSwitchCase="'number'" numeric numericType={{numericType}} id="first-name" required="required" class="form-control col-md-7 col-xs-12"
            [(ngModel)]="model" (change)="onModelChange($event)">
        </div>
    </div>
    `
})
export class BaseFormInput {
    @Input() title: string;
    @Input() model: any;
    @Input() numericType?: string;
    @Input() formInputType: string = "text";
    @Output() modelChange: EventEmitter<any> = new EventEmitter();

    public onModelChange():void{
        this.modelChange.emit(this.model);
    }
}