import {Promise} from "../models/promise";

export interface IResourceManager {
    getLocales(): any;
    loadLocale(locales: Array<string>): Promise;
}