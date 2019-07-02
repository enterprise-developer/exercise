import { IIoCBuilder } from "./iiocBuilder";
import {SingletonBuilder} from "./singletonBuilder";
import {TransientBuilder} from "./transientBuilder";
import { IoCLifeCycle } from "../../models/enum";

export class IoCBuilderFactory{
    public static create(registration: IIoCRegistration): IIoCBuilder{
        switch(registration.lifeCycle){
            case IoCLifeCycle.Singleton:
                return new SingletonBuilder(registration);
            case IoCLifeCycle.Transient:
                return new TransientBuilder(registration);
            default:
            throw "invalid lifecycle"
        }
    }
}