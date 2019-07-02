import {IIoCBuilder} from "./builder/iiocBuilder";
import {IoCBuilderFactory} from "./builder/iocBuilderFactory";
import {IAppSettingService} from "../services/iappSettingService";
import { IoCNames } from "../models/enum";
export class IoCFactory{
    public static create():IIoCContainer{
        return new IoCContainer();
    }
}
class IoCContainer implements IIoCContainer{
    private registrations:Array<IIoCRegistration>=[];
    public import(registrations:Array<IIoCRegistration>):void{
        this.registrations=registrations;
    }
    /**
     * string: resolve custom ioc
     * class: resovle angular object
     */
    public resolve(nameOrType:any):any{
        if(typeof nameOrType=="function"){
            return this.resolveAngularObject(nameOrType);
        }
        let registraion=this.registrations.firstOrDefault((item: IIoCRegistration)=>{
            return item.name==nameOrType;
        });
        if(!registraion){throw "invalid ... ";}
        let iocBuilder:IIoCBuilder= IoCBuilderFactory.create(registraion);
        return iocBuilder.build();
    }
    private resolveAngularObject(type: any):any{
        let appSettingService:IAppSettingService= window.ioc.resolve(IoCNames.IAppSettingService);
        let injector:any= appSettingService.getInjector();
        return injector.get(type);
    }
}