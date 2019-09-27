import { IResourceManager } from "./iresourceManager";

export class ResourceManager implements IResourceManager{
    private locales:any;
    public getLocale():any{
        return this.locales;
    }
}