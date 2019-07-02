import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
    selector:"user-preview",
    template:`
    <div >
    <div class="x_panel">
      <div class="x_title">
        <h2>User information</h2>
        <div class="clearfix"></div>
      </div>
      <div class="x_content">
        <br>
        <form data-parsley-validate="" class="form-horizontal form-label-left" novalidate="">
          <div class="form-group">
            <label class="control-label col-md-3 col-sm-3 col-xs-12" >First Name</label>
            <div class="col-md-6 col-sm-6 col-xs-12">
              <input type="text" name="first-name" (keypress)="onValueChanged($event)" [(ngModel)]="firstName" required="required" class="form-control col-md-7 col-xs-12">
            </div>
          </div>
        </form>
      </div>
    </div>
  </div>
    `
})
export class UserPreview{
    @Input() firstName: string;
    @Output() firstNameChange: EventEmitter<string>=new EventEmitter(); 

    public onValueChanged():void{
        this.firstNameChange.emit(this.firstName);
    }
}