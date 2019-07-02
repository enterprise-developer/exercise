export interface IValidator{
    add(errorKey:string):void;
    throwIfError():void;
    hasError():boolean;
}