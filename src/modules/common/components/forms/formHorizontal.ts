import { Component } from "@angular/core";

@Component({
    selector: "form-horizontal",
    template: `
    <form id="demo-form2" data-parsley-validate="" class="form-horizontal form-label-left" novalidate="">
        <ng-content></ng-content>
        
        <div class="ln_solid"></div>

        <div class="form-group">
            <ng-content select="form-buttons"></ng-content>
        </div>

  </form>
    `
})
export class FormHorizontal {

}