import { IIoCBuilder } from "./iiocBuilder";

export class TransientBuilder implements IIoCBuilder{
    private registration:IIoCRegistration;
    constructor(reg:IIoCRegistration){
        this.registration=reg;
    }
    public build():any{
        return new this.registration.instanceOf();
    }
}