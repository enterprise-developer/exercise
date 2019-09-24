import {IIoCRegistration} from "../enum";
import {IBuilder} from "./builder/ibuilder";
import {BuilderFactory}  from "./builder/builderFactory";
export class IoCContainer{
    private registration : Array<IIoCRegistration>=[];
    public import(regs:Array<IIoCRegistration>):void{
        this.registration = regs;
    }
    public resolve(name:string): any{

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
}