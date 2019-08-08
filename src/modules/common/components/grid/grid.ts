import { Input, DoCheck, Component, AfterViewInit } from "@angular/core";
import { IGridOption, IGridColumn } from "./igridOption";
import guidHelper from "../../helpers/guid";
import {Promise} from "../../models/promise";
@Component({
    selector: "grid",
    template: `<table id="{{id}}" width="100%">
                </table>`
})
export class Grid implements DoCheck, AfterViewInit {
    @Input() options: IGridOption;
    public id: any;
    private grid: any;
    constructor() {
        this.id = guidHelper.create();
    }
    public ngAfterViewInit(): void {
        let self = this;
        this.options.data.subscribe((def: Promise) => {
            self.renderDataTable(def.data || []);
        });
    }
    public ngDoCheck(): void {
        if (window.jQuery(String.format("#{0}", this.id)).length <= 0) { return; }
        if (!!this.grid) { return; }
        this.grid = window.jQuery(String.format("#{0}", this.id)).DataTable({
            columns: this.renderColums()
        });
    }
    private renderDataTable(data: Array<any>): void {
        if (!this.grid || !this.grid.rows) { return; }
        this.grid.clear();
        this.grid.rows.add(data).draw(false);
    }
    private renderColums(): Array<any> {
        let columns: Array<any> = [];
        if (!this.options.columns) { return; }
        this.options.columns.forEach((item: IGridColumn) => {
            columns.push({
                data: item.field,
                title: item.title
            });
        });
        return columns;
    }
}