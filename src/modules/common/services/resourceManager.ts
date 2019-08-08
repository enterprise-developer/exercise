import { IResourceManager } from "./iresourceManager";
import { Promise, PromiseFactory } from "../models/promise";
import { LanguageCodes, IoCNames, ConnectorType } from "../models/enums";
import { IConnector } from "../connector/iconnector";
import { ConnectorFactory } from "../connector/connectorFactory";

export class ResourceManager implements IResourceManager {
    private locales: any = {};
    private languageCode: string = LanguageCodes.EN;
    public getLocales(): any {
        return this.locales;
    }

    public loadLocales(locales: Array<string>): Promise {
        let def = PromiseFactory.create();
        locales = locales || [];
        let self = this;
        locales.forEach((name: string) => {
            def.resolveAll(self.getLocaleByName(name));
        });
        return def;
    }

    private getLocaleByName(name: string): Promise {
        let def = PromiseFactory.create();

        let url: string = String.format("resources/locales/{0}.{1}.json", name, this.languageCode);
        let iconnector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        let self = this;
        iconnector.get(url).then(function (data: any) {
            self.locales[name] = data;
            def.resolve();
        });
        return def;
    }
}