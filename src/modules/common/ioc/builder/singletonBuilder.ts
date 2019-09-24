import { IBuilder } from "./ibuilder";
import { IIoCRegistration } from "../../enum";

export class SingletonBuilder implements IBuilder{
    private item:IIoCRegistration;
    constructor(item:IIoCRegistration){
        this.item=item;
    }
    public build():any{
        if(!this.item.instance){
            this.item.instance=new this.item.instanceOf();
        }
        return this.item.instance;
    }
}