import { IIoCBuilder } from "./iiocBuilder";
import { IIoCRegistration, IoCLifecycle } from "../../models/enums";
import {IoCBuilderSingleton} from "./iocBuilderSingleton";
import {IoCBuilderTransient} from "./iocBuilderTransient";
export class IoCBuilderFactory {
    public static create(registration: IIoCRegistration): IIoCBuilder {
        switch (registration.lifecycle) {
            case IoCLifecycle.Singleton:
                return new IoCBuilderSingleton(registration);
            case IoCLifecycle.Transient:
                return new IoCBuilderTransient(registration);
            default:
                throw ("invalid lifecyle");
        }
    }
}