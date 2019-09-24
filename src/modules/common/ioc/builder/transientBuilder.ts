import { IBuilder } from "./ibuilder";
import { IIoCRegistration } from "../../enum";

export class TransientBuilder implements IBuilder{
    private item: IIoCRegistration;
    constructor(item: IIoCRegistration){
        this.item=item;
    }
    public build():any{
        return new this.item.instanceOf();
    }
}