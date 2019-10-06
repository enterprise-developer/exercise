import { IIoCBuilder } from "./iiocBuilder";
import { IIoCRegistration, IoCLifecycle } from "../../models/enums";
import {SingletonBuilder} from "./singletonBuilder";
import {TransientBuilder} from "./transientBuilder";

export class IoCBuilderFactory {
    public static create(registration: IIoCRegistration): IIoCBuilder {
        switch (registration.lifecycle) {
            case IoCLifecycle.Singleton:
                return new SingletonBuilder(registration);
            case IoCLifecycle.Transient:
            default:
                return new TransientBuilder(registration);
        }
    }
}