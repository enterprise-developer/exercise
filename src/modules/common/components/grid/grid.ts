import { Component, Input, AfterContentInit, DoCheck } from "@angular/core";
import { BaseComponent } from "../../models/baseComponent";
import { Promise } from "../../models/promise";
import guidHelper from "../../helpers/guidHelper";


@Component({
    selector:"grid",
    template:`<table id="{{id}}" class="table"></table>`
})
export class Grid extends BaseComponent implements AfterContentInit, DoCheck{
    @Input() options: IGridOption;
    private grid:any;
    public ngAfterContentInit(){
        let self=this;
        if(!self.options.dataSource){return;}
        self.options.dataSource.subscribe((arg: any)=>{
            self.onDataSourceChanged(arg);
        });
    }
    private onDataSourceChanged(items: Array<any>){
        if(!this.grid){return}
        this.grid.clear();
        this.grid.rows.add(items||[]).draw();
    }
    public ngDoCheck(){
        let self=this;
        if(window.jQuery(String.format("#{0}", self.id)).length<=0){return;}
        if(!!self.grid){return;}
        let actions:Array<any>=self.options.actions||[];
        actions.forEach((action:IGridItemAction)=>{
            action.id=guidHelper.newGuid();
        });
        self.grid=window.jQuery(String.format("#{0}", this.id)).DataTable({
            columns:self.getColumns()
        });
        window.setTimeout(()=>{
            this.bindEvents();
        }, 2000);
        
    }
    private bindEvents():void{
        let self=this;
        window.jQuery(".grid-item-action").on("click", function(){
            let actionId=window.jQuery(this).attr("item-id");
            let action:IGridItemAction = self.options.actions.firstOrDefault((item:IGridItemAction)=>{return item.id==actionId;});
            let dataItem:any=self.grid.row(window.jQuery(this).parents("tr")).data();
            if(!action || !action.handler){return;}
            action.handler(dataItem);
        });
    }
    private getColumns():any{
        let columns:Array<any>=[];
        /**
         * [
         * {data:"name", text:"Name"},
         * {data:"email", title:"Email"},
         * {}
         * 
         * ]
         * 
         * 
         */
        if(!this.options || !this.options.columns){return columns;}
        this.options.columns.forEach((colDef: IGridColumn)=>{
            let col: any={data:colDef.field, "title":colDef.title};
            if(colDef.transform){
                col.render=(val: any, editor:any, dataItem:any)=>{
                    return colDef.transform(val);
                }
            }
            columns.push(col);
        });
        let self=this;
        if(this.options.actions && this.options.actions.length>0){
            columns.push({data:"", title:"", render:function(val: any, editor:any, dataItem:any){
                let html:string = self.getGridActionAsHtml(self.options.actions, dataItem);
                return html;
            }});       
        }
        return columns;
    }
    private getGridActionAsHtml(actions:Array<IGridItemAction>, dataItem: any):string{
        let html="";
        actions.forEach((action: IGridItemAction)=>{
            if(action.isValid && !action.isValid(dataItem)){return;}
            html=String.format("{0}<button class='grid-item-action' item-id='{2}'>{1}</button>", html, action.text, action.id);
        });
        return html;
    }
}

export interface IGridOption{
    dataSource: Promise;
    columns:Array<IGridColumn>;
    actions:Array<IGridItemAction>
}
export interface IGridColumn{
    field:string;
    title:string;
    transform?:(val:any)=>string;
}
export interface IGridItemAction{
    id?:string;
    text: string;
    handler:(dataItem: any)=>void;
    isValid?:(dataItem: any)=>boolean;
}