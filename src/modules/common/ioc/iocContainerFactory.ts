import {IoCContainer} from "./iocContainer";
export class IoCContainerFactory{
    public static create():IoCContainer{
        return new IoCContainer();
    }
}