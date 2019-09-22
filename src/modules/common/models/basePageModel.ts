import { IButtonModel } from "./ibuttonModel";

export class BasePageModel{
    public buttons: Array<IButtonModel> = [];
    public addButton(text:string, cls:string, handler:(event?:any)=>void):void{
            this.buttons.push(
                {
                    text:text,
                    cls:cls,
                    onClicked:handler
                }
            );
    }
}