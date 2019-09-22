import { Component } from "@angular/core";

@Component({
    selector: "form-horizontal",
    template: `
    <form id="demo-form2" data-parsley-validate="" class="form-horizontal form-label-left" novalidate="">
        <ng-content></ng-content>
        <div class="form-group">
            <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                <ng-content select="form-buttons"></ng-content>
            </div>
        </div>
    </form>
    `
})
export class FormHorizontal {

}