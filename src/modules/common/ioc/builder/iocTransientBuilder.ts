import { IIoCRegistration } from "../../models/enums";
import { IIoCBuilder } from "./iiocBuilder";

export class IoCTransientBuilder implements IIoCBuilder {
    private registration: IIoCRegistration;
    constructor(registration: IIoCRegistration) {
        this.registration = registration;
    }

    public build():any{
        return new this.registration.instanceOf();
    }
}