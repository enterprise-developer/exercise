import { IConnector } from "./iconnector";
import { PromiseFactory, Promise } from "../models/promise";
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';
import { ResponseModel } from "../models/responseModel";
import { HttpStatusCode, IoCNames } from "../models/enums";
import { ValidationResult } from "../models/ivalidationResult";
import { IEventManager } from "../services/ieventManager";
export class JsonConnector implements IConnector {
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

    public post(url: string, item: any): Promise {
        let def = PromiseFactory.create();
        let self = this;
        let httpClient: Http = window.ioc.resolve(Http);
        httpClient.post(url, item).map((response: any) => {
            return response.json();
        }).subscribe((data: any) => {
            self.processResponse(def, data);
        });
        return def;
    }

    private processResponse(def: Promise, response: ResponseModel) {
        if (response.errors != null && response.statusCode != HttpStatusCode.OK) {
            def.reject();
        }
        if (response.errors == null && response.data != null) {
            def.resolve(response.data);
        }
        if (response.errors == null && response.data == null) {
            def.resolve(response);
        }
        if (response.errors != null) {
            let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
            response.errors.forEach((error: string) => {
                eventManager.publish(new ValidationResult(error, false));
            });
        }
    }


}