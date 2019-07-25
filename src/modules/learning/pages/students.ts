import { Component } from "@angular/core";
import { BasePage } from "@app/common";
@Component({
    template: `
    <page [title]= "i18n.learning.students.title">
        <page-content>
            <grid [options]="model.options">
            </grid>
        </page-content>
    </page>
    `
})
export class Students extends BasePage {

}