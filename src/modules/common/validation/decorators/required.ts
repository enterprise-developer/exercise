import { IEventManager } from "../../event/ieventManager";
import { IoCNames, ClassConst, ValidationStatus } from "../../models/enum";
export function required(errorKey:string){
    return function(target: any, propertyName:string){
        let privateProperty=String.format("_{0}", propertyName);

        let metadata=window.Reflect.getMetadata(ClassConst.Metadata, target.constructor)||{};
        metadata.validationResult=metadata.validationResult||[];
        metadata.propMapper=metadata.propMapper||{};
        
        metadata.propMapper[privateProperty]=propertyName;
        window.Reflect.defineMetadata(ClassConst.Metadata, metadata, target.constructor);

        let setFunc=function(val: string){
            target[privateProperty]=val;
            let eventManager:IEventManager = window.ioc.resolve(IoCNames.IEventManager);
            
            if(!val || val.trim()==""){
                eventManager.publish(errorKey);
                metadata.validationResult.push(errorKey);
            }else{
                eventManager.publish(errorKey, ValidationStatus.Success);
                metadata.validationResult.remove(errorKey);
            }
            window.Reflect.defineMetadata(ClassConst.Metadata, metadata, target.constructor);
        }

        let getFunc=function(){
            return target[privateProperty];
        }
        Object.defineProperty(target, propertyName,{
            set: setFunc,
            get: getFunc
        });
    }

}