import { IIoCBuilder } from "./iioCBuilder";
import { IIoCRegistration, IoCLifecycle } from "../../models/enums";
import { IoCSingletonBuilder } from "./iocSingletonBuilder";
import { IoCTransientBuilder } from "./iocTransientBuilder";
export class IoCBuilderFactory {
    public static create(registration: IIoCRegistration): IIoCBuilder {
        switch (registration.lifecycle) {
            case IoCLifecycle.Singleton:
                return new IoCSingletonBuilder(registration);
            case IoCLifecycle.Transient:
                return new IoCTransientBuilder(registration);
            default:
                throw "invalid lifecycle";
        }
    }
}