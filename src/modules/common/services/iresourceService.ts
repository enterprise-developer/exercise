import { Promise } from "../models/promise";
export interface IResourceService {
    getLocales(): any;
    loadLocales(locales: Array<string>): Promise;
    resolve(key: string): string;
}