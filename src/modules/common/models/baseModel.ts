import {ClassConst} from "./enum";
export class BaseModel{
    public isValid():boolean{
        let metadata:any=window.Reflect.getMetadata(ClassConst.Metadata, this.constructor);
        return !metadata || !metadata.validationResult || metadata.validationResult.isEmpty();
    }
    public toJSON(){
        let result: any={};
        let metadata=window.Reflect.getMetadata(ClassConst.Metadata, this.constructor);
        for(let p in this){
            if(metadata && metadata.propMapper.hasOwnProperty(p)){
                let value=this[p];
                result[metadata.propMapper[p]]=value;
                continue;
            }
            if(!this.hasOwnProperty(p)){continue;}
            result[p]=this[p];
        }
        return result;
    }
}