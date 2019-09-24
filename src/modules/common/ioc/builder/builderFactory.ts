import { IIoCRegistration, IoCLifecycle } from "../../enum";
import { IBuilder } from "./ibuilder";
import {TransientBuilder} from "./transientBuilder";
import {SingletonBuilder} from "./singletonBuilder";

export class BuilderFactory{
    public static create(item: IIoCRegistration):IBuilder{
        switch(item.lifecycle){
            case IoCLifecycle.Transient:
                return new TransientBuilder(item);
            case IoCLifecycle.Singleton:
                return new SingletonBuilder(item);
        }
    }
}