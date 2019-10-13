import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
    selector: "form-input-number",
    template: `
    <div class="form-group">
        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">{{title}}
        </label>
        <div class="col-md-6 col-sm-6 col-xs-12">
        <input type="number" numeric numericType={{type}} id="first-name" required="required" class="form-control col-md-7 col-xs-12"
        [(ngModel)]="model" (change)="onModelChange($event)"
        >
        </div>
  </div>
    `
})
export class FormInputNumber {
    @Input() title: string;
    @Input() model: any;
    @Input() type: string = "number";
    @Output() modelChange: EventEmitter<any> = new EventEmitter();

    public onModelChange():void{
        this.modelChange.emit(this.model);
    }
}