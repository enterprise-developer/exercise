import { Component, Input, DoCheck, AfterViewInit } from "@angular/core";
import { IGridOption } from "./igridOption";
import guidHelper from "../../helpers/guid";
import { IGridColumn } from "./igridColumn";
import { Promise } from "../../models/promise";
import { IGridAction } from "./igridAction";
@Component({
    selector: "grid",
    template: `
    <table class="table" id="{{id}}" withd="100%">
    </table>
    `
})
export class Grid implements DoCheck, AfterViewInit {
    @Input() options: IGridOption;
    public id: string;
    private grid: any;
    constructor() {
        this.id = guidHelper.create();
    }

    public ngDoCheck(): void {
        if (window.jQuery(String.format("#{0}", this.id)).length <= 0 || !!this.grid) {
            return;
        }

        let actions: Array<any> = this.options.actions || [];
        actions.forEach((action: IGridAction) => {
            action.id = guidHelper.create();
        });

        this.grid = window.jQuery(String.format("#{id}", this.id)).DataTable({
            columns: this.renderColumns()
        });

        this.bindEvent();
    }

    private renderColumns(): Array<any> {
        let columns: Array<any> = [];
        if (!this.options.columns) {
            return;
        }

        this.options.columns.forEach((item: IGridColumn) => {
            columns.push({
                data: item.field,
                title: item.title
            });
        });
        let self = this;
        if (this.options.actions && this.options.actions.length > 0) {
            columns.push({
                data: "",
                title: "",
                render: function (data: any, type: any, row: any) {
                    return self.renderAction(self.options.actions, row);
                },
            });
        }
        return columns;
    }

    private renderAction(actions: Array<IGridAction>, item: any): string {
        let html: string = "";
        actions.forEach((action: IGridAction) => {
            html = String.format("{0}<button id='{1}' class='grid-action'>{2}</button>", html, action.id, action.text);
        });
        return html;
    }
    public ngAfterViewInit(): void {
        let self = this;
        this.options.data.subscribe((subPromise: Promise) => {
            self.renderDataTable(subPromise.data);
        });
    }

    private renderDataTable(data: any) {
        if (!this.grid || !this.grid.rows) {
            return;
        }

        this.grid.clear();
        this.grid.rows.add(data).draw(false);
    }

    private bindEvent(): void {
        let self= this;
        window.jQuery(".grid-action").on("click", function () {
            let actionId = window.jQuery(this).attr("id");
            let action: IGridAction = self.options.actions.firstOrDefault((item: IGridAction) => {
                return item.id == actionId;
            });
            if (!action || !action.handler) {
                return;
            }
            action.handler(self.grid.row(window.jQuery(this).parents("tr")).data());
        });
    }
}