import { Directive, Input, AfterContentInit, ElementRef } from "@angular/core";
import { IoCNames, ValidationStatus } from "../models/enum";
import {IEventManager} from "../event/ieventManager";
import { BaseComponent } from "../models/baseComponent";
@Directive({
    selector:"[validation]"
})
export class Validation extends BaseComponent implements AfterContentInit{
    @Input("validation") messages:Array<string>;
    private ui:ElementRef;
    constructor(ref:ElementRef){
        super();
        this.ui=ref;
    }
    ngAfterContentInit(){
        let eventManager: IEventManager=window.ioc.resolve(IoCNames.IEventManager);
        let self=this;
        this.messages.forEach((message: string)=>{
            eventManager.subscribe(message, (arg: any)=>{self.onTriggered(arg);});
        });
    }
    private onTriggered(arg: any):void{
        if(arg.option==ValidationStatus.Success){
            this.ui.nativeElement.classList.remove(ValidationConst.INVALID_STATE);    
            this.ui.nativeElement.title="";
        }else{
            this.ui.nativeElement.classList.add(ValidationConst.INVALID_STATE);
            this.ui.nativeElement.title=this.i18nHelper.resolve(arg.key, arg.option);
        }
    }
}
const ValidationConst={
    INVALID_STATE:"validation--fail"
};