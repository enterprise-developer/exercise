import { Component, Input, DoCheck, AfterViewInit } from "@angular/core";
import { IGridOption, IGridColumn } from "../../models/igridOption";
import { Promise } from "../../models/promise";
import guidHelper from "../../helpers/guidHelper";

@Component({
    selector: "grid",
    template: `
        <table id="{{id}}" class ="table">
        </table>
    `
})
export class Grid implements DoCheck, AfterViewInit {
    @Input() options: IGridOption;
    private id: string;
    private grid: any;

    constructor() {
        this.id = guidHelper.create();
    }

    public ngDoCheck() {
        if (window.jQuery(String.format("#{0}", this.id)).length <= 0 || !!this.grid) {
            return;
        }

        this.grid = window.jQuery(String.format("#{0}", this.id)).DataTable({
            columns: this.renderColumns()
        });
    }

    private renderColumns(): Array<any> {
        let columns: Array<any> = [];
        if (!this.options && !this.options.columns) {
            return;
        }

        this.options.columns.forEach((item: IGridColumn) => {
            columns.push({
                data: item.field,
                title: item.title
            });
        });

        return columns;
    }

    public ngAfterViewInit(): void {

        let self = this;
        this.options.data.subscribe((def: Promise) => {
            self.renderDataTable(def.data || []);
        });
    }

    private renderDataTable(data: Array<any>): void {
        if (!this.grid || !this.grid.rows) {
            return;
        }

        this.grid.clear();
        this.grid.rows.add(data).draw(false);
    }
}