import { IIoCBuilder } from "./iiocBuilder";
import { IIoCRegistration } from "../../models/enums";
export class IoCSingletonBuilder implements IIoCBuilder {
    private registration: IIoCRegistration;
    constructor(registration: IIoCRegistration) {
        this.registration = registration;
    }

    public build(): any {
        if (!this.registration.instance) {
            this.registration.instance = new this.registration.instanceOf();
        }
        return this.registration.instance;

    }
}