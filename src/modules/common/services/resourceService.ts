import { IResourceService } from "./iresourceService";
import { Promise, PromiseFactory } from "../models/promise";
import { LanguageCode, ConnectorType } from "../models/enums";
import { IConnector } from "../connector/iconnector";
import { ConnectorFactory } from "../connector/connectorFactory";
export class ResourceService implements IResourceService {

    private locales: any = {};
    private languageCode: LanguageCode.EN;
    public getLocales(): any {
        return this.locales;
    }

    public loadLocales(locales: Array<string>): Promise {
        let def = PromiseFactory.create();
        locales = locales || [];
        let self = this;
        locales.forEach((name: string) => {
            def.resolveAll(self.getLocalesByName(name));
        });
        return def;
    }

    private getLocalesByName(name: string): Promise {
        let def = PromiseFactory.create();
        let url = String.format("resources/locales/{0}.{1}.json", name, this.languageCode);
        let iConnector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        let self = this;
        iConnector.get(url).then((response: any) => {
            self.locales[name] = response;
            def.resolve();
        });
        return def;
    }

    public resolve(key: string): string {
        let subKeys = key.split(".");
        let result = this.locales;
        subKeys.forEach((sub: string) => {
            result = result[sub];
        });
        return result;
    }
}