import { IValidator } from "./ivalidator";
import { IEventManager } from "../event/ieventManager";
import { IoCNames } from "../models/enum";

export class Validator implements IValidator{
    private keys:Array<string>=[];
    public add(errorKey:string):void{
        this.keys.push(errorKey);
    }
    public throwIfError():void{
        if(this.keys.isEmpty()){return;}
        let eventManager:IEventManager = window.ioc.resolve(IoCNames.IEventManager);
        this.keys.forEach((key: string)=>{
            eventManager.publish(key);
        });
    }
    public hasError():boolean{
        return this.keys.isEmpty();
    }
}