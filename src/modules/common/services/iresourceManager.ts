import { Promise } from "../models/promise";

export interface IResourceManager{
    load(locales:Array<any>):Promise;
    getLocales():any;
    changeLanguage(languageCode:string):void;
    //addnewUser.firstnameWasRequired => value
    resolve(key:string, context?:any):string;
}