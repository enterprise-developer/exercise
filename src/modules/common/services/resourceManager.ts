import { IResourceManager } from "./iresourceManager";
import { Promise, PromiseFactory } from "../models/promise";
import { LanguageCode, ConnectorType } from "../models/enums";
import { IConnector } from "../connector/iconnector";
import { ConnectorFactory } from "../connector/connectorFactory";

export class ResourceManager implements IResourceManager {
    private locales: any = {};
    private languageCode: string = LanguageCode.EN;

    public getLocales(): any {
        return this.locales;
    }

    public loadLocale(locales: Array<string>): Promise {
        let def: Promise = PromiseFactory.create();
        locales = locales || [];
        let self = this;
        locales.forEach((name: string) => {
            def.resolveAll(self.getLocaleByName(name));
        });
        return def;
    }

    private getLocaleByName(name: string): Promise {
        let def: Promise = PromiseFactory.create();
        let self = this;
        let url = String.format("/resources/locales/{0}.{1}.json", name, this.languageCode);
        let connector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        connector.get(url).then((data: any) => {
            self.locales[name] = data;
            def.resolve();
        });
        return def;
    }

    public resolve(key: string): string {
        let result = this.locales;
        let subKeys = key.split(".");
        subKeys = subKeys || [];
        subKeys.forEach((sub: string) => {
            result = result[sub];
        });
        return result;
    }
}