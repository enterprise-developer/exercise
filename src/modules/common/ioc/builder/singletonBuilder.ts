import { IIoCBuilder } from "./iiocBuilder";

export class SingletonBuilder implements IIoCBuilder{
    private registration:IIoCRegistration;
    constructor(reg:IIoCRegistration){
        this.registration=reg;
    }
    public build():any{
        if(!this.registration.instance){
            this.registration.instance= new this.registration.instanceOf();
        }
        return this.registration.instance;
    }
}