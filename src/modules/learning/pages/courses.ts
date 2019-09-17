import { Component } from "@angular/core";
import {BasePage} from "../../common/basePage"
@Component({
template:   `
<div class="x_panel">
    <div class="x_title">
        <h2>{{i18n.learning.pages.courses.title_}}</small></h2>
        <div class="clearfix"></div>
        </div>
        <div class="x_content">
        <table class="table">
            <thead>
                <tr>
                    <th>#</th>
                    <th>{{i18n.learning.pages.courses.title}}</th>
                    <th>{{i18n.learning.pages.courses.decription}}</th>
                    <th>{{i18n.learning.pages.courses.actions}}</th>
                </tr>
            </thead>
            <tbody>
            <tr *ngFor="let course of courses">
                <th scope="row">{{course.title}}</th>
                <td>{{course.decription}}</td>
                <td>
                </td>
            </tr>
            </tbody>
        </table>
     </div>
</div>`
})
export class Courses extends BasePage {}