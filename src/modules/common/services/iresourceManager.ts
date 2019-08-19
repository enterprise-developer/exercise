import { Promise } from "../models/promise";
export interface IResourceManager {
    getLocales(): any;
    loadLocales(locales: Array<string>): Promise;
    resolve(key: string): string;
}