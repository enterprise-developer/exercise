import { IIoCBuilder } from "./iiocBuilder";
import { IIoCRegistration } from "../../models/enums";

export class IoCBuilderTransient implements IIoCBuilder {
    private registration: IIoCRegistration;
    constructor(registration: IIoCRegistration) {
        this.registration = registration;
    }
    public build(): any {
        return new this.registration.instanceOf();
    }
}