import {IIoCRegistration} from "../enum";
import {IBuilder} from "./builder/ibuilder";
import {BuilderFactory}  from "./builder/builderFactory";
import { Injector } from "@angular/core";

export class IoCContainer{
    private registration : Array<IIoCRegistration>=[];
    private injector:Injector;
    public import(regs:Array<IIoCRegistration>):void{
        this.registration = regs;
    }
    public resolve(name:any): any{
        if(typeof name != "string"){
            return this.resolveAngularObject(name);
        }
        let item:IIoCRegistration = this.registration.firstOrDefault(
            (item: IIoCRegistration)=>{
                return item.name==name;
            }
        );
        if(!item){
            throw String.format("'{0}' registration was not found", name);
        }
        let builder:IBuilder=BuilderFactory.create(item);
        return builder.build();
    }
    public resolveAngularObject(name:any):any{
        return this.injector.get(name);
    }
    public setInjector(arg:any):void{
        this.injector=arg;
    }


}