import { IConnector } from "./iconnector";
import { PromiseFactory } from "../models/promise";
import { Promise } from "../models/promise";
import { Http } from "@angular/http";
import "rxjs/add/operator/map";
import { RepsonseModel } from "../models/repsonseModel";
import { HttpStatusCode, IoCNames } from "../models/enums";
import { IEventManager } from "../services/ieventManager";
import { ValidationResult } from "../models/ivalidationResult";
export class JsonConnector implements IConnector {
    public delete(url: string): Promise {
        let def = PromiseFactory.create();
        let self = this;
        let httpClient: Http = window.ioc.resolve(Http);
        httpClient.delete(url).map((response: any) => {
            return response.json();
        }).subscribe((data: any) => {
            self.processResponse(def, data);
        });
        return def;
    }
    public get(url: string): Promise {
        let def = PromiseFactory.create();
        let self = this;
        let httpClient: Http = window.ioc.resolve(Http);
        httpClient.get(url).map((response: any) => {
            return response.json();
        }).subscribe((data: any) => {
            self.processResponse(def, data);
        });
        return def;
    }

    public post(url: string, model: any): Promise {
        let def = PromiseFactory.create();
        let self = this;
        let httpClient: Http = window.ioc.resolve(Http);
        httpClient.post(url, model).map((response: any) => {
            return response.json();
        }).subscribe((data: any) => {
            self.processResponse(def, data);
        });
        return def;
    }
    private processResponse(def: Promise, response: RepsonseModel) {
        if (response.errors != null) {
            if (response.statusCode != HttpStatusCode.OK) {
                def.reject();
            }
            let eventManage: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
            response.errors.forEach((error: string) => {
                eventManage.publish(new ValidationResult(error, false));
            });
        }

        if (response.errors == null) {
            let itemResolve = !!response.data ? response.data : response;
            def.resolve(itemResolve);
        }
    }
}