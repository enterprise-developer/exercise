import { Component, Input } from "@angular/core";

@Component({
    selector: "page",
    template: `
    <div class="x_panel">
        <div class="x_title">
            <h2>{{title}}</h2>
            <ng-content select="page-command"></ng-content>
            <div class="clearfix"></div>
        </div>        
        <div class="x_content">
            <ng-content select="page-content"></ng-content>
        </div>
    </div>
    `
})
export class Page {
    @Input() title: string;
}