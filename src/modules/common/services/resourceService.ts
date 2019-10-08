import { IResourceService } from "./iresourceService";
import { Promise, PromiseFactory } from "../models/promise";
import { LanguageCode, ConnectorType } from "../models/enums";
import { IConnector } from "../connector/iconnector";
import { ConnectorFactory } from "../connector/connectorFactory";
export class ResourceService implements IResourceService {
    private languageCode: LanguageCode = LanguageCode.EN;
    private locales: any = {};
    public getLocales(): any {
        return this.locales;
    }

    public loadLocales(locales: Array<string>): Promise {
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
        let url: string = String.format("resources/locales/{0}.{1}.json", name, this.languageCode);
        let iconnector: IConnector = ConnectorFactory.create(ConnectorType.Json);
        let self = this;
        iconnector.get(url).then((data: any) => {
            self.locales[name] = data;
            def.resolve();
        });
        return def;
    }
}