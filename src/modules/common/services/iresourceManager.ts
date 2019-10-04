import { Promise } from "../models/promise";

export interface IResourceManager{
    getLocale():any;
    loadLocales(locales:Array<string>):Promise;
}